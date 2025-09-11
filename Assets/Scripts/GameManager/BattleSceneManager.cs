using UnityEngine;

namespace BattleScene
{
    public class BattleSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            // 打开场景最初UI界面
            UIMediator.Instance.OpenPanel(SceneName.BattleScene, PanelName.BattlePanel.ToString());

            // 播放BGM
            AudioManager.Instance.PlayBGM(AudioType.Bgm, AudioName.bgm_1Low);

            facade = new Facade();
        }

        private void Start()
        {
            EventCenter.Instance.RegisterEvent(EventType.OnPlayerDie, OnPlayerDie);
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

        #region 事件集
        private void OnPlayerDie()
        {
            UnityTools.WaitThenCallFun(this, 1f, () =>
            {
                UIMediator.Instance.OpenPanel(SceneName.BattleScene, PanelName.RevivePanel.ToString());
            });
        }
        #endregion
    }
}