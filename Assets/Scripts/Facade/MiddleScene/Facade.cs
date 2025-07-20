namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private ItemSystem itemSystem;
        private InputSystem inputSystem;
        private PlayerSystem playerSystem;
        private EnemySystem enemySystem;
        //private UISystem uiSystem;

        private CameraSystem cameraSystem;
        private AudioSystem musicSystem;

        protected override void OnInit()
        {
            base.OnInit();

            itemSystem = new ItemSystem();
            inputSystem = new InputSystem();
            playerSystem = new PlayerSystem();
            enemySystem = new EnemySystem();
            //uiSystem = new UISystem();

            cameraSystem = new CameraSystem();
            musicSystem = new AudioSystem();

            GameMediator.Instance.RegisterSystem(itemSystem);
            GameMediator.Instance.RegisterSystem(inputSystem);
            GameMediator.Instance.RegisterSystem(playerSystem);
            GameMediator.Instance.RegisterSystem(enemySystem);
            //GameMediator.Instance.RegisterSystem(uiSystem);

            GameMediator.Instance.RegisterSystem(cameraSystem);
            GameMediator.Instance.RegisterSystem(musicSystem);

            EventCenter.Instance.RigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
                playerSystem.TurnOnController();
            });

            // HACK
            enemySystem.TurnOnController();
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            itemSystem.GameUpdate();
            inputSystem.GameUpdate();
            playerSystem.GameUpdate();
            enemySystem.GameUpdate();
            //uiSystem.GameUpdate();
            cameraSystem.GameUpdate();
            musicSystem.GameUpdate();
        }
    }
}
