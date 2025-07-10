namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private InputController _inputController;
        private PlayerController _playerController;
        private UIController _uiController;

        protected override void OnInit()
        {
            base.OnInit();
            _inputController = new InputController();
            _playerController = new PlayerController();
            _uiController = new UIController();

            GameMediator.Instance.RegisterController(_inputController);
            GameMediator.Instance.RegisterController(_playerController);
            GameMediator.Instance.RegisterController(_uiController);

            GameMediator.Instance.RegisterSystem(new CameraSystem());

            EventCenter.Instance.RigisterEvent(EventType.OnSelectPlayerComplete, false, () =>
            {
                _playerController.TurnOnController();
            });

        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _inputController.GameUpdate();
            _playerController.GameUpdate();
            _uiController.GameUpdate();
        }
    }
}
