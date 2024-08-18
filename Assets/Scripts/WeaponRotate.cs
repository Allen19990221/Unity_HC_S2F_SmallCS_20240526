
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
        protected Transform crossHair;
        [SerializeField, Header("要旋轉物件")]
        private Transform rotateTarget;
        [SerializeField, Header("要旋轉武器")]
        private SpriteRenderer sprWeapon;
        #endregion

        #region 事件
        protected virtual void Update()
        {
            Rotate();
            Flip();
        }
        #endregion

        #region 方法
        

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
