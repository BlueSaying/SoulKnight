namespace BattleScene
{
    public class Facade : AbstractFacade
    {
        protected override void OnInit()
        {
            base.OnInit();

            AddSystem<GlobalSystem>();
            AddSystem<ItemSystem>();
            AddSystem<InputSystem>();
            AddSystem<MapSystem>();
            AddSystem<CameraSystem>();
            AddSystem<PlayerSystem>();
            AddSystem<EnemySystem>();
            AddSystem<WeaponSystem>();
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            systems[typeof(GlobalSystem)].TurnOn();
            systems[typeof(ItemSystem)].TurnOn();
            systems[typeof(InputSystem)].TurnOn();
            systems[typeof(MapSystem)].TurnOn();

            EventCenter.Instance.RegisterEvent(EventType.OnFinishRoomCreate, () =>
            {
                systems[typeof(CameraSystem)].TurnOn();
                systems[typeof(PlayerSystem)].TurnOn();
                systems[typeof(EnemySystem)].TurnOn();
                systems[typeof(WeaponSystem)].TurnOn();
            });

            UnityTools.Instance.WaitThenCallFun(this, 0.1f, () =>
            {
                (systems[typeof(MapSystem)] as MapSystem).CreateLevel(LevelType.Forest);
            });
        }

        #region 事件集

        #endregion
    }
}