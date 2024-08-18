using UnityEngine;

namespace Kuoan
{
    /// <summary>
    /// 武器旋轉:玩家
    /// </summary>
    public class WeaponRotatePlayer : WeaponRotate
    {
        protected override void Update()
        {
            MousePosition();
            base.Update();
        }
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
    }
}

