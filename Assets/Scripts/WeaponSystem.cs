using TMPro;
using UnityEngine;

namespace Kuoan
{
    ///<summary>
    ///武器系統
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
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

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            Fire();
        }

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
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject tempBullet = Instantiate(dataWeapon.bulletPrefab, spawnBulletPoint.position, Quaternion.identity);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(spawnBulletPoint.right * dataWeapon.bulletSpeed);
            }
        }
        
    }
}
