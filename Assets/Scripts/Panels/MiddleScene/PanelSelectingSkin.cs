using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class PanelSelectingSkin : IPanel
    {
        private GameObject selectingPlayer;

        public PanelSelectingSkin(IPanel parent) : base(parent)
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
                // TODO:GameMediator.Instance.GetController<PlayerController>().SetMainPlayerSkin(Enum.Parse<PlayerSkinType>(skinName));
                EventCenter.Instance.NotifyEvent(EventType.OnSelectSkinComplete);
                panel.SetActive(false);
                EnterPanel<PanelBattle>();
            });

            EventCenter.Instance.RigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
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