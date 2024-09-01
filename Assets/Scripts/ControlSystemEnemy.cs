using UnityEngine;

namespace Kuoan
{
    /// <summary>
    /// 控制系統:敵人
    /// </summary>
    public enum WeaponType
        {
            //定義列舉
            //列舉自帶有編號從玲開始，手槍0、衝鋒槍1、散彈槍2、狙擊槍3
            Pistol, MachineGun, ShotGun, Sniper
        }
    public class ControlSystemEnemy : ControlSystem
    {
        /// <summary>
        /// 檢查玩家是否在射線範圍內
        /// </summary>
        public bool checkPlayer => CheckPlayer();
        

        [SerializeField, Header("敵人武器")]
        private WeaponType weaponType;
        [SerializeField, Header("武器物件")]
        private GameObject[] weapons;

        private Transform weaponFirePoint;
        private Transform player;

        [Header("偵測玩家射線")]
        [SerializeField]
        private Color checkPlayerRayColor = new Color(0.5f, 1, 0.5f, 0.7f);
        [SerializeField, Range(0, 15)]
        private float checkPlayerLength = 3.5f;
        [SerializeField]
        private LayerMask checkPlayerLayer = 1 << 3 | 1 << 6;

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            //如果槍口為空值 就跳出
            if (weaponFirePoint == null) return;
            Gizmos.color = checkPlayerRayColor;
            //繪製射線(起點，方向*長度)
            Gizmos.DrawRay(
                weaponFirePoint.position, weaponFirePoint.right * checkPlayerLength);
        }

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.Find(GameManager.playerName).transform;

        }

        protected override void Update()
        {
            if (player == null) return;

            base.Update();
            if (CheckPlayer())
            {
                rig.velocity = Vector2.zero;
                ani.SetFloat(parMove, 0);
                return;
            }

            float move = player.position.x < transform.position.x ? -1 : +1;
            Move(move);
            Ladder(move);
        }

        private bool CheckPlayer()
        {
            
            //2D 物理射線碰撞(起點，方向，長度，圖層)
            RaycastHit2D hit = Physics2D.Raycast(
            weaponFirePoint.position, weaponFirePoint.right, checkPlayerLength, checkPlayerLayer);
            //如果 碰到的物件是空值 就傳回 false
            if (hit.collider == null) return false;
            //如果 碰到物件的名稱 等於 玩家名稱 就傳回 true
            return hit.collider.name.Equals(GameManager.playerName);
        } 
        
        ///<summary>
        ///設定武器
        ///</summary>
        ///<param name="_weaponType">武器類型</param>
        public void SetWeaponType(WeaponType _weaponType)
        {
            weaponType = _weaponType;
                
            //隱藏非選取武器，顯示選取武器
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(i == (int)weaponType);
            }
            //獲得顯示武器的子彈生成位置
            weaponFirePoint = weapons[(int)weaponType].transform.Find("子彈生成位置");
        }
    }

}

