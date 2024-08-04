
using UnityEngine;

namespace Kuoan
{
    /// <summary>
    /// 子彈
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;

        private void Awake()
        {
            Destroy(gameObject, dataWeapon.bulletLife);
        }

    }
}
