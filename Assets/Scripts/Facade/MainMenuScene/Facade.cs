using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenuScene
{
    public class Facade : AbstractFacade
    {
        private UIController _uiController;
        protected override void OnInit()
        {
            base.OnInit();
            _uiController = new UIController();
            GameMediator.Instance.RegisterController(_uiController);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _uiController.GameUpdate();
        }
    }
}
