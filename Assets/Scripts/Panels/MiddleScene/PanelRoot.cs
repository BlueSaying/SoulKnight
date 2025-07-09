using UnityEngine.UI;
using UnityEngine;

namespace MiddleScene
{
    public class PanelRoot : IPanel
    {
        public PanelRoot() : base(null)
        {
            children.Add(new PanelRoom(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            Resume();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            EnterPanel<PanelRoom>();
        }
    }
}