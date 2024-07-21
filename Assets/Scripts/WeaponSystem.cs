using TMPro;
using UnityEngine;
using System.Collections;

namespace Kuoan
{
    ///<summary>
    ///武器系統
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;
        [SerializeField, Header("子彈生成位置")]
        private Transform spawnBulletPoint;
        [Header("介面")]
        [SerializeField]
        private TMP_Text textWeaponName;
        [SerializeField]
        private TMP_Text textBulletCurrent;
        [SerializeField]
        private TMP_Text textBulletTotal;
        [SerializeField]
        private TMP_Text textMagazinePrice;

        private int bulletCurrent;
        private int bulletTotal;
        private int magazineCount;
        private bool canFire = true;
        private bool isReload;
        #endregion

        #region 事件
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            Fire();
            Reload();
#if UNITY_EDITOR           
            Test();
#endif
        }
        #endregion

        #region 方法
        ///<summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            textWeaponName.text = dataWeapon.weaponName;
            textBulletCurrent.text = $"子彈:{dataWeapon.magazineBulletCount}";
            textBulletTotal.text = "總數:0";
            textMagazinePrice.text = $"價格:{dataWeapon.magazineBulletPrice}";
            bulletCurrent = dataWeapon.magazineBulletCount;
            bulletTotal = 0;
        }

        private void Fire()
        {
            if (!canFire) return;
            if (bulletCurrent <= 0) return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject tempBullet = Instantiate(dataWeapon.bulletPrefab, spawnBulletPoint.position, Quaternion.identity);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(spawnBulletPoint.right * dataWeapon.bulletSpeed);
                bulletCurrent--;
                UpdateUI();
                StartCoroutine(bulletCD());
            }
        }

        private IEnumerator bulletCD()
        {
            canFire = false;
            yield return new WaitForSeconds(dataWeapon.bulletCD);
            canFire = true;
        }
        private void UpdateUI()
        {
            textBulletCurrent.text = $"子彈:{bulletCurrent}";
            textBulletTotal.text = $"總數:{dataWeapon.magazineBulletCount * magazineCount}";
        }
        private void Reload()
        {
            if (magazineCount <= 0) return;
            if (isReload) return;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartCoroutine(ReloadHandle());
            }
        }

        private IEnumerator ReloadHandle()
        {
            isReload = true;
            bulletCurrent = 0;
            UpdateUI();
            yield return new WaitForSeconds(dataWeapon.magazineCD);
            bulletCurrent = dataWeapon.magazineBulletCount;
            magazineCount--;
            UpdateUI();
            isReload = false;
        }

        ///summary
        /// 測試:填充彈匣
        ///</summary>
        private void Test()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                magazineCount++;
                UpdateUI();
            }

        } 
        #endregion

    }
}
