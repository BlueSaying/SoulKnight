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
                GameMediator.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.staticCamera);

                UIManager.Instance.OpenPanel(PanelName.RoomPanel.ToString());
                //UIManager.Instance.OpenPanel(PanelName.GemPanel.ToString());
                UIManager.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });

            // 下一步
            UInextButton.onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectPlayerComplete);
                UIManager.Instance.OpenPanel(PanelName.SelectingSkinPanel.ToString());
                UIManager.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });
        }
    }
}