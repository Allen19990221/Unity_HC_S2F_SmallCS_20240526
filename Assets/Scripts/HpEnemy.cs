using UnityEngine;
using UnityEngine.UI;

namespace Kuoan
{
    /// <summary>
    /// 血量系統:敵人
    /// </summary>
    public class HpEnemy : HpSystem
    {
        [SerializeField, Header("畫布血條介面")]
        private GameObject perfabCanvasHp;
        private GameObject temp;
        private void Awake()
        
        {
            //生成血條介面
            temp = Instantiate(perfabCanvasHp);
            //指定血條的跟隨系統目標 為 此物件
            temp.GetComponent<FollowSystem>().SetTarget(transform);
            //將敵人血條指定到血條變數
            SetImgHp(temp.transform.Find("血條").GetComponent<Image>());
        }
        protected override void Dead()
        {
            base.Dead();
            //使用單例模式
            //腳本名稱.實體.公開成員
            //請GM更新擊殺數與金幣
            GameManager.instance.UpdateKillAndCoin();
            Destroy(temp);
        }
    }
}

