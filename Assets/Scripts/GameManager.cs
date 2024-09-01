using UnityEngine;
using TMPro;

namespace Kuoan
{
    /// <summary>
    /// 遊戲管理器
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance
        {
            //唯讀(其他腳本只能取得此資料)
            get
            {
                //如果實體為空的 就尋找場井上有GM得物件並存放到實體
                if (_instance == null) _instance = FindObjectOfType<GameManager>();
                //傳回實體
                return _instance;
            }
        }
        
        //用來存放單例的變數(實體)
        private static GameManager _instance;

        //const 常數:不會變得值
        //存取方式:腳本名稱:常數名稱
        public const string playerName = "玩家_伊莉莎白";

        private TMP_Text textKillCount, textCoin;
        private int killCount, coin;
        private int coinIncrease = 100;

        private void Awake()
        {
            textKillCount = GameObject.Find("文字擊殺數量").GetComponent<TMP_Text>();
            textCoin = GameObject.Find("文字金幣數量").GetComponent<TMP_Text>();
        }

        /// <summary>
        /// 更新擊殺數與金幣數值跟介面
        /// </summary>
        public void UpdateKillAndCoin()
        {
            killCount++;
            coin += coinIncrease;
            textKillCount.text = $"擊殺數量:{killCount}";
            textCoin.text = $"金幣:{coin}";
        }
    }
}

