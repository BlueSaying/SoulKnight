namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        private ItemSystem itemSystem;
        private InputSystem inputSystem;
        private PlayerSystem playerSystem;
        private EnemySystem enemySystem;
        private WeaponSystem weaponSystem;

        private CameraSystem cameraSystem;
        private AudioSystem musicSystem;

        protected override void OnInit()
        {
            base.OnInit();

            itemSystem = new ItemSystem();
            inputSystem = new InputSystem();
            playerSystem = new PlayerSystem();
            enemySystem = new EnemySystem();
            weaponSystem = new WeaponSystem();

            cameraSystem = new CameraSystem();
            musicSystem = new AudioSystem();

            GameMediator.Instance.RegisterSystem(itemSystem);
            GameMediator.Instance.RegisterSystem(inputSystem);
            GameMediator.Instance.RegisterSystem(playerSystem);
            GameMediator.Instance.RegisterSystem(enemySystem);
            GameMediator.Instance.RegisterSystem(weaponSystem);

            GameMediator.Instance.RegisterSystem(cameraSystem);
            GameMediator.Instance.RegisterSystem(musicSystem);

            EventCenter.Instance.ReigisterEvent(EventType.OnSelectSkinComplete, false, () =>
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
            weaponSystem.GameUpdate();
            cameraSystem.GameUpdate();
            musicSystem.GameUpdate();
        }
    }
}
