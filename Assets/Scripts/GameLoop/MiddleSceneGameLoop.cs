using UnityEngine;

namespace MiddleScene
{
    public class MiddleSceneGameLoop : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
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
            if (Input.GetKeyDown(KeyCode.U)) GameMediator.Instance.GetSystem<InputSystem>().isLimitedWeapon = false;
        }
    }
}