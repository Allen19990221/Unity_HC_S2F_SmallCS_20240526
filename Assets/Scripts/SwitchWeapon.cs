using UnityEngine;

namespace Kuoan
{ 
    /// <summary>
    /// 切換武器
    /// </summary>
    public class SwitchWeapon : MonoBehaviour
    {
        [SerializeField, Header("所有武器")]
        private GameObject[] weapons;
        [SerializeField, Header("所有武器的切換按鈕")]
        private KeyCode[] weaponKeys =
        {
            KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4
        };

        private void Update()
        {
            Switch();
        }

        private void Switch()
        {
            for (int i = 0; i < weaponKeys.Length; i++)
            {
                if (Input.GetKeyDown(weaponKeys[i]))
                {
                    for (int j = 0; j < weapons.Length; j++)
                    {
                        weapons[j].SetActive(false);
                    }

                    weapons[i].SetActive(true);
                }
            }
        }
    }

}
