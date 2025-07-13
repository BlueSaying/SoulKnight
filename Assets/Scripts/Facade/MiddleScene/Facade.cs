namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private ItemController itemController;
        private InputController inputController;
        private PlayerController playerController;
        private UIController uiController;

        private CameraSystem _cameraSystem;

        protected override void OnInit()
        {
            base.OnInit();

            itemController = new ItemController();
            inputController = new InputController();
            playerController = new PlayerController();
            uiController = new UIController();

            _cameraSystem = new CameraSystem();

            GameMediator.Instance.RegisterController(itemController);
            GameMediator.Instance.RegisterController(inputController);
            GameMediator.Instance.RegisterController(playerController);
            GameMediator.Instance.RegisterController(uiController);

            GameMediator.Instance.RegisterSystem(_cameraSystem);

            EventCenter.Instance.RigisterEvent(EventType.OnSelectPlayerComplete, false, () =>
            {
                playerController.TurnOnController();
            });

        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            itemController.GameUpdate();
            inputController.GameUpdate();
            playerController.GameUpdate();
            uiController.GameUpdate();
        }
    }
}
