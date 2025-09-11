using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            // 打开UI界面
            UIMediator.Instance.OpenPanel(SceneName.MainMenuScene,PanelName.MainMenuPanel.ToString());

            // 播放BGM
            AudioManager.Instance.PlayBGM(AudioType.Bgm, AudioName.bgm_1Low);

            facade = new Facade();
        }

        private void OnEnable()
        {
            facade.TurnOn();
        }

        private void FixedUpdate()
        {
            facade.FixedUpdate();
        }

        void Update()
        {
            facade.Update();

            if (Input.GetKeyDown(KeyCode.T))
            {
                if (UIMediator.Instance.IsPanelOpened(Generic.PanelName.TestPanel.ToString()))
                {
                    UIMediator.Instance.ClosePanel(Generic.PanelName.TestPanel.ToString());
                }
                else
                {
                    UIMediator.Instance.OpenPanel(SceneName.Generic, Generic.PanelName.TestPanel.ToString());
                }
            }
        }

        private void OnDisable()
        {
            facade.TurnOff();
        }
    }
}