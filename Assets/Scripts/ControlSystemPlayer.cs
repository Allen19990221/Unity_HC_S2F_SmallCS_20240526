using UnityEngine;

namespace Kuoan
{
    /// <summary>
    /// 控制系統:玩家
    /// </summary>
    public class ControlSystemPlayer : ControlSystem
    {
        protected override void Update()
        {
            base.Update();
            PlayerInput();
        }
        private void PlayerInput()
        {
            // 得玩家的獲水平按鍵：A、D 與左右
            // 玩家按下左 -1，右 +1，沒按 0
            float h = Input.GetAxis("Horizontal");
            Move(h);
            Ladder(h);
        }
        
    }

}


