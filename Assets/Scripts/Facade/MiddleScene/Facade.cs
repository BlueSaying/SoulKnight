

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private InputController _inputController;
        private PlayerController _playerController;

        protected override void OnInit()
        {
            base.OnInit();
            _inputController = new InputController();
            _playerController = new PlayerController();

            GameMediator.Instance.RegisterController(_inputController);
            GameMediator.Instance.RegisterController(_playerController);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _playerController.GameUpdate();
            _inputController.GameUpdate();
        }
    }
}
