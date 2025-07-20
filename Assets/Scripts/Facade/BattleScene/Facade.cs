using UnityEngine;

namespace BattleScene
{
    public class Facade : AbstractFacade
    {
        private ItemController itemController;
        private InputController inputController;
        private PlayerController playerController;
        private EnemyController enemyController;
        private UIController uiController;

        private CameraSystem cameraSystem;
        //private MusicSystem musicSystem;

        protected override void OnInit()
        {
            base.OnInit();

            RoomCreator.Instance.CreateLevel(LevelType.Forest);

            itemController = new ItemController();
            inputController = new InputController();
            playerController = new PlayerController();
            enemyController = new EnemyController();
            uiController = new UIController();

            cameraSystem = new CameraSystem();
            //musicSystem = new MusicSystem();

            GameMediator.Instance.RegisterController(itemController);
            GameMediator.Instance.RegisterController(inputController);
            GameMediator.Instance.RegisterController(playerController);
            GameMediator.Instance.RegisterController(enemyController);
            GameMediator.Instance.RegisterController(uiController);

            GameMediator.Instance.RegisterSystem(cameraSystem);
            //GameMediator.Instance.RegisterSystem(musicSystem);

            EventCenter.Instance.RigisterEvent(EventType.OnFinishRoomCreate, false, () =>
            {
                itemController.TurnOnController();
                inputController.TurnOnController();
                playerController.TurnOnController();
                enemyController.TurnOnController();
                uiController.TurnOnController();
            });
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            itemController.GameUpdate();
            inputController.GameUpdate();
            playerController.GameUpdate();
            enemyController.GameUpdate();
            uiController.GameUpdate();
        }
    }
}