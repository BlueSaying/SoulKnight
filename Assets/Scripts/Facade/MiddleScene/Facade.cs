namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        protected override void OnInit()
        {
            base.OnInit();

            AddSystem<GlobalSystem>();
            AddSystem<ItemSystem>();
            AddSystem<InputSystem>();
            AddSystem<PlayerSystem>();
            AddSystem<EnemySystem>();
            AddSystem<WeaponSystem>();
            AddSystem<CameraSystem>();
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            systems[typeof(GlobalSystem)].TurnOn();
            systems[typeof(InputSystem)].TurnOn();
            systems[typeof(CameraSystem)].TurnOn();
            systems[typeof(PlayerSystem)].TurnOn();

            EventCenter.Instance.RegisterEvent(EventType.OnSelectSkinComplete, OnSelectSkinComplete);
        }

        protected override void OnExit()
        {
            base.OnExit();

            EventCenter.Instance.RemoveEvent(EventType.OnSelectSkinComplete, OnSelectSkinComplete);
        }

        #region 事件集
        public void OnSelectSkinComplete()
        {
            systems[typeof(ItemSystem)].TurnOn();
            systems[typeof(EnemySystem)].TurnOn();
            systems[typeof(WeaponSystem)].TurnOn();
        }
        #endregion
    }
}
