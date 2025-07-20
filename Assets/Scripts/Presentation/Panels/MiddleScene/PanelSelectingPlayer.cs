using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class PanelSelectingPlayer : Panel
    {
        private GameObject selectingPlayer;

        public PanelSelectingPlayer(Panel parent) : base(parent)
        {
            children.Add(new PanelSelectingSkin(this));
        }

        protected override void OnInit()
        {
            base.OnInit();

            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonBack").onClick.AddListener(() =>
            {
                OnExit();
            });
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonNext").onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectPlayerComplete);
            });

            EventCenter.Instance.RigisterEvent(EventType.OnSelectPlayerComplete, false, () =>
            {
                GetPanel<PanelSelectingSkin>().SetSelectingPlayer(selectingPlayer);
                EnterPanel<PanelSelectingSkin>();
                panel.SetActive(false);
            });
        }

        protected override void OnEnter()
        {
            base.OnEnter();
        }

        public void SetSelectingPlayer(GameObject selectingPlayer)
        {
            this.selectingPlayer = selectingPlayer;
        }
    }
}