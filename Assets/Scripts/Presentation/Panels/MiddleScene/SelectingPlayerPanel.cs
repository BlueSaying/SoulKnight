using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class SelectingPlayerPanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            // 返回
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack").onClick.AddListener(() =>
            {
                UIManager.Instance.OpenPanel(PanelName.RoomPanel.ToString());
                UIManager.Instance.OpenPanel(PanelName.GemPanel.ToString());
                UIManager.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });

            // 下一步
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext").onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectPlayerComplete);
            });

            EventCenter.Instance.RigisterEvent(EventType.OnSelectPlayerComplete, false, () =>
            {
                UIManager.Instance.OpenPanel(PanelName.SelectingSkinPanel.ToString());
                UIManager.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });
        }


    }
}