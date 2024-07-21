
using UnityEngine;

namespace Kuoan
{
    /// <summary>
    /// 旋轉武器
    /// </summary>
    // MonoBehaviour允許腳本掛在物件上
    public class WeaponRotate : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("準心")]
        private Transform crossHair;
        [SerializeField, Header("要旋轉物件")]
        private Transform rotateTarget;
        [SerializeField, Header("要旋轉武器")]
        private SpriteRenderer sprWeapon;
        #endregion

        #region 事件
        private void Update()
        {
            MousePosition();
            Rotate();
            Flip();
        }
        #endregion

        #region 方法
        private void MousePosition()
        {
            //輸入(Input) 的 滑鼠座標(mousePosition)
            Vector3 mousePosition = Input.mousePosition;
            //滑鼠座標 = 主要攝影機 螢幕座標轉為世界座標
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //要變更文字的顏色: $"<color=#rgb>輸入文字</color> 
            //print($"<color=#3f3>滑鼠世界座標:{mousePosition}</color>");
            //因為主要攝影機Z軸在-10，滑鼠的z也會跑到-10，要把滑鼠位置改為0
            mousePosition.z = 0;
            crossHair.position = mousePosition;
        }

        private void Rotate()
        {
            //y軸的api為right，x軸為up，z軸為forward
            //此行將物件的y軸的向量 = 準心-物件的向量
            transform.right = crossHair.position - transform.position;
        }

        private void Flip()
        {
            if (crossHair.position.x > rotateTarget.position.x)
            {
                //print($"<color=#3f3>在右邊!</color>");
                rotateTarget.eulerAngles = Vector3.zero;
                sprWeapon.flipY = false;
            }
            else
            {
                //print($"<color=#f33>在左邊!</color>");
                rotateTarget.eulerAngles = new Vector3(0, 180, 0);
                sprWeapon.flipY = true;
            }
        } 
        #endregion
    }

}
