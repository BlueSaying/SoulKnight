using UnityEngine;

namespace BattleScene
{
    public class Facade : AbstractFacade
    {
        private ItemSystem itemSystem;
        private InputSystem inputSystem;
        private PlayerSystem playerSystem;
        private EnemySystem enemySystem;
        //private UISystem uiSystem;

        private CameraSystem cameraSystem;
        private AudioSystem audioSystem;

        protected override void OnInit()
        {
            base.OnInit();

            RoomCreator.Instance.CreateLevel(LevelType.Forest);

            itemSystem = new ItemSystem();
            inputSystem = new InputSystem();
            playerSystem = new PlayerSystem();
            enemySystem = new EnemySystem();
            //uiSystem = new UISystem();

            cameraSystem = new CameraSystem();
            audioSystem = new AudioSystem();

            GameMediator.Instance.RegisterSystem(itemSystem);
            GameMediator.Instance.RegisterSystem(inputSystem);
            GameMediator.Instance.RegisterSystem(playerSystem);
            GameMediator.Instance.RegisterSystem(enemySystem);
            //GameMediator.Instance.RegisterSystem(uiSystem);

            GameMediator.Instance.RegisterSystem(cameraSystem);
            GameMediator.Instance.RegisterSystem(audioSystem);

            EventCenter.Instance.ReigisterEvent(EventType.OnFinishRoomCreate, false, () =>
            {
                itemSystem.TurnOnController();
                inputSystem.TurnOnController();
                playerSystem.TurnOnController();
                enemySystem.TurnOnController();
                //uiSystem.TurnOnController();
                cameraSystem.TurnOnController();
                audioSystem.TurnOnController();
            });
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
            audioSystem.GameUpdate();
        }
    }
}