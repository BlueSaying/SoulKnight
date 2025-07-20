using UnityEngine;

namespace MiddleScene
{
    public class MiddleSceneGameLoop : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            UIManager.Instance.OpenPanel(PanelName.RoomPanel.ToString());
            UIManager.Instance.OpenPanel(PanelName.GemPanel.ToString());

            facade = new Facade();
        }

        void Update()
        {
            facade.GameUpdate();
            if (Input.GetKeyDown(KeyCode.U)) GameMediator.Instance.GetSystem<InputSystem>().isLimitedWeapon = false;
        }
    }
}