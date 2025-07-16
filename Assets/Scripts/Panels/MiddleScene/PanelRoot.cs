using UnityEngine.UI;
using UnityEngine;

namespace MiddleScene
{
    public class PanelRoot : BasePanel
    {
        public PanelRoot() : base(null)
        {
            children.Add(new PanelRoom(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            Resume();
            EventCenter.Instance.RigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
                panel.SetActive(false);
            });
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            EnterPanel<PanelRoom>();
        }
    }
}