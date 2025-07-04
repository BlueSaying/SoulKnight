using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenuScene
{
    public class UIController : AbstractController
    {
        private PanelRoot rootPanel;
        public UIController() { }
        protected override void OnInit()
        {
            base.OnInit();
            rootPanel = new PanelRoot();
        }
        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            rootPanel.GameUpdate();
        }
    }
}
