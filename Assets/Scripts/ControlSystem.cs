using UnityEngine;

namespace KID
{
    /// <summary>
    /// 控制系統
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        // SerializeField 序列化，將變數顯示在面板
        // Header 標題，在變數上顯示文字
        // Range(最小，最大) 設定變數範圍限制
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 3.5f;

        private Rigidbody2D rig;

        private void Awake()
        {
            // 獲得此物件身上的 2D 剛體並存放到變數 rig 內
            rig = GetComponent<Rigidbody2D>();
        }
    }
}
