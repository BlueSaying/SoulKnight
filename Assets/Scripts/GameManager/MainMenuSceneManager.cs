using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            UIMediator.Instance.OpenPanel(PanelName.MainMenuPanel.ToString());

            facade = new Facade();
        }

        private void OnEnable()
        {
            facade.TurnOn();
        }

        void Update()
        {
            facade.GameUpdate();
        }

        private void OnDisable()
        {
            facade.TurnOff();
        }
    }
}