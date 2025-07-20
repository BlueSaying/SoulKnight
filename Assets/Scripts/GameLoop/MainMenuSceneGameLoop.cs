using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuSceneGameLoop : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            UIManager.Instance.OpenPanel(PanelName.MainMenuPanel.ToString());

            facade = new Facade();
        }

        void Update()
        {
            facade.GameUpdate();
        }
    }
}