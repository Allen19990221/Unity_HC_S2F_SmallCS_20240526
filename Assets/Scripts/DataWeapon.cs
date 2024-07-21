using UnityEngine;

namespace Kuoan
{
    //在跟目錄建立自訂定菜單
    [CreateAssetMenu(menuName = "Kuoan/Weapon")]
    public class DataWeapon : ScriptableObject
    {
        [Header("武器名稱")]
        public string weaponName;
        [SerializeField, Header("彈匣裝彈數量"), Range(0, 60)]
        public int magazineBulletCount;
        [SerializeField, Header("彈匣價格"), Range(0, 10000)]
        public int magazineBulletPrice;
        [SerializeField, Header("彈匣冷卻"), Range(0, 20)]
        public float magazineCD;
        [SerializeField, Header("子彈生命週期"), Range(0, 2)]
        public float bulletLife;
        [SerializeField, Header("子彈傷害"), Range(0, 50)]
        public float bulletDamage;
        [SerializeField, Header("子彈後座力"), Range(0, 2)]
        public float bulletRecoil;
        [SerializeField, Header("子彈冷卻"), Range(0, 2)]
        public float bulletCD;
        [SerializeField, Header("子彈速度"), Range(0, 2000)]
        public float bulletSpeed;
        [Header("子彈預製物")]
        public GameObject bulletPrefab;
    }

}
