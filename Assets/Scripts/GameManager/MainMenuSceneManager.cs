using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            UIMediator.Instance.OpenPanel(SceneName.MainMenuScene,PanelName.MainMenuPanel.ToString());
            AudioManager.Instance.PlayBGM(AudioType.bgm, AudioName.bgm_1Low);

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