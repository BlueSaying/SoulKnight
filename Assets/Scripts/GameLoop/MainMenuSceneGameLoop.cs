using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuSceneGameLoop : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            UIMediator.Instance.OpenPanel(PanelName.MainMenuPanel.ToString());

            facade = new Facade();
        }

        void Update()
        {
            facade.GameUpdate();
        }
    }
}