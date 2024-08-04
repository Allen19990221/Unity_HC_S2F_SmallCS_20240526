using TMPro;
using UnityEngine;

namespace Kuoan
{
    /// <summary>
    /// 武器系統:玩家
    /// </summary>
    /// ///子類別:父類別(繼承)
    public class WeaponSystemPlayer : WeaponSystem
    {
        [SerializeField, Header("介面父物件:按鈕武器")]
        private Transform uiParent;

        private TMP_Text textWeaponName;
        private TMP_Text textBulletCurrent;
        private TMP_Text textBulletTotal;
        private TMP_Text textMagazinePrice;

      
        protected override void Awake()
        {
            base.Awake();
            updateUI = UpdateUI;
        }
        protected override void Update()
        {
            base.Update();
#if UNITY_EDITOR
            Test();
#endif
        }

        protected override void Initialize()
        {
            base.Initialize();

            textWeaponName = uiParent.GetChild(0).GetComponent<TMP_Text>();
            textBulletCurrent = uiParent.GetChild(1).GetComponent<TMP_Text>();
            textBulletTotal = uiParent.GetChild(2).GetComponent<TMP_Text>();
            textMagazinePrice = uiParent.GetChild(3).GetComponent<TMP_Text>();

            textWeaponName.text = dataWeapon.weaponName;
            textBulletCurrent.text = $"子彈:{dataWeapon.magazineBulletCount}";
            textBulletTotal.text = "總數:0";
            textMagazinePrice.text = $"價格:{dataWeapon.magazineBulletPrice}";
        }

        private void UpdateUI()
        {
            textBulletCurrent.text = $"子彈:{bulletCurrent}";
            textBulletTotal.text = $"總數:{dataWeapon.magazineBulletCount * magazineCount}";
        }

        private void Test()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                magazineCount++;
                UpdateUI();
            }
        }
    }
}

