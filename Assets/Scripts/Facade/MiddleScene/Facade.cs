using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private PlayerController _playerController;
        protected override void OnInit()
        {
            base.OnInit();
            _playerController = new PlayerController();

            GameMediator.Instance.Register_Controller(_playerController);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _playerController.GameUpdate();
        }
    }
}
