using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class SelectingPlayerPanel : Panel
    {
        private Button UIbackButton;
        private Button UInextButton;


        protected override void Awake()
        {
            base.Awake();

            UIbackButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack");
            UInextButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext");

            // 返回
            UIbackButton.onClick.AddListener(() =>
            {
                SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.staticCamera);

                UIMediator.Instance.OpenPanel(PanelName.RoomPanel.ToString());
                //UIManager.Instance.OpenPanel(PanelName.GemPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });

            // 下一步
            UInextButton.onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectPlayerComplete);
                UIMediator.Instance.OpenPanel(PanelName.SelectingSkinPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });
        }
    }
}