using UnityEngine;
using System.Collections;
using System;

namespace Kuoan
{
    ///<summary>
    ///武器系統
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("武器資料")]
        protected DataWeapon dataWeapon;
        [SerializeField, Header("子彈生成位置")]
        private Transform spawnBulletPoint;

        protected int bulletCurrent;
        protected int bulletTotal;
        protected int magazineCount;
        private bool canFire = true;
        private bool isReload;
        #endregion
        //修飾詞:
        //私人:private:僅限此類別存取
        //公開:public:所有類別都可存取
        //保護:protected:允許子類別存取

        //虛擬:virtual:允許子類別覆寫

        //Action:
        protected Action updateUI; 
        #region 事件
        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void Update()
        {
            
        }
        #endregion

        #region 方法
        ///<summary>
        /// 初始化
        /// </summary>
        protected virtual void Initialize()
        {
            bulletCurrent = dataWeapon.magazineBulletCount;
            bulletTotal = 0;
        }

        /// <summary>
        /// 開槍方法
        /// </summary>
        /// <param name="fire">是否要開槍</param>
        protected void Fire(bool fire)
        {
            if (!canFire) return;
            if (bulletCurrent <= 0) return;

            if (fire)
            {
                GameObject tempBullet = Instantiate(dataWeapon.bulletPrefab, spawnBulletPoint.position, Quaternion.identity);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(spawnBulletPoint.right * dataWeapon.bulletSpeed);
                bulletCurrent--;
                updateUI?.Invoke();
                StartCoroutine(bulletCD());
            }
        }

        private IEnumerator bulletCD()
        {
            canFire = false;
            yield return new WaitForSeconds(dataWeapon.bulletCD);
            canFire = true;
        }
        
        /// <summary>
        /// 換彈匣
        /// </summary>
        /// <param name="reload">是否要換彈匣</param>
        protected void Reload(bool reload)
        {
            if (magazineCount <= 0) return;
            if (isReload) return;
            if (reload)
            {
                StartCoroutine(ReloadHandle());
            }
        }

        private IEnumerator ReloadHandle()
        {
            isReload = true;
            bulletCurrent = 0;
            updateUI?.Invoke();
            yield return new WaitForSeconds(dataWeapon.magazineCD);
            bulletCurrent = dataWeapon.magazineBulletCount;
            magazineCount--;
            updateUI?.Invoke();
            isReload = false;
        }

        ///summary
        /// 測試:填充彈匣
        ///</summary>
       
        #endregion

    }
}
