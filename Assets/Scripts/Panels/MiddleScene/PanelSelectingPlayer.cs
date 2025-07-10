using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class PanelSelectingPlayer : IPanel
    {
        private GameObject selectingPlayer;

        public PanelSelectingPlayer(IPanel parent) : base(parent)
        {
            children.Add(new PanelBattle(this));
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
                GameMediator.Instance.GetController<PlayerController>().SetMainPlayer(Enum.Parse<PlayerType>(selectingPlayer.name));
                EventCenter.Instance.NotifyEvent(EventType.OnSelectPlayerComplete);
                panel.SetActive(false);
                EnterPanel<PanelBattle>();
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