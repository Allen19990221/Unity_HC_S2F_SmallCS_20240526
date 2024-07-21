using UnityEngine;
using System.Collections;

namespace Kuoan 
{ 
    /// <summary>
    /// 學習協同程序
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        //1.引用System.Collections;
        //2.定義傳回 IEnumerator 方法
        //3.方法內使用關鍵字 yield return 時間
        //4.使用 StartCoroutine 啟動方法

        private void Awake()
        {
            StartCoroutine(Test());
        }
        private IEnumerator Test()
        {
            print("<color=#f36>第一行</color>");
            yield return new WaitForSeconds(1);
            print("<color=#f36>第二行</color>");
            yield return new WaitForSeconds(2);
            print("<color=#f36>第三行</color>");
        }
    }
}

