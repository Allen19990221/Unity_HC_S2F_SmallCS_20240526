
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

        //OCE2 碰撞事件，物件有碰撞氣碰到其他物件時執行事件
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }

    }
}
