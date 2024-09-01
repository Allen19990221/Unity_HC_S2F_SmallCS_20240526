using UnityEngine;
using UnityEngine.UI;

namespace Kuoan
{
    public class HpSystem : MonoBehaviour
    {
        [SerializeField, Header("血條圖片")]
        private Image imgHp;
        [SerializeField, Header("爆炸特效")]
        private GameObject explosion;
        private float hp = 100, hpMax = 100;
        private string bulletName = "子彈";

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //如果 碰到物件的名稱包含"子彈"兩個字 就受傷
            if (collision.gameObject.name.Contains(bulletName))
            {
                float bulletDamage = collision.gameObject.GetComponent<Bullet>().bulletDamage;
                Damage(bulletDamage);
            }
        }
        private void Damage(float damage)
        {
            hp -= damage;
            // 更新血條圖片填滿長度
            imgHp.fillAmount = hp / hpMax;
            print(hp);
            if (hp <= 0) Dead();  
        }
        protected virtual void Dead()
        {
            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1);
            Destroy(gameObject);
        }
        public void SetImgHp(Image _imgHp)
        {
            imgHp = _imgHp;
        }
    }
}

