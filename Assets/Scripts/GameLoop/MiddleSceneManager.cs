using UnityEngine;

namespace MiddleScene
{
    public class MiddleSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            // 打开场景最初UI界面
            UIMediator.Instance.OpenPanel(PanelName.RoomPanel.ToString());
            UIMediator.Instance.OpenPanel(PanelName.GemPanel.ToString());

            // 实例化相应的角色
            PlayerFactory.Instance.InstantiatePlayer(PlayerType.Knight, new Vector2(9, 7), Quaternion.identity);
            PlayerFactory.Instance.InstantiatePlayer(PlayerType.Rogue, new Vector2(6, -2), Quaternion.identity);

            facade = new Facade();
        }

        void Update()
        {
            facade.GameUpdate();

            if (Input.GetKeyDown(KeyCode.U)) TestManager.Instance.isUnlockWeapon = !TestManager.Instance.isUnlockWeapon;
        }
    }
}