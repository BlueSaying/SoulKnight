
namespace BattleScene
{
    public class Facade : AbstractFacade
    {
        protected override void OnInit()
        {
            base.OnInit();

            AddSystem<ItemSystem>();
            AddSystem<InputSystem>();
            AddSystem<CameraSystem>();
            AddSystem<PlayerSystem>();
            AddSystem<EnemySystem>();
            AddSystem<WeaponSystem>();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            systems[typeof(ItemSystem)].TurnOn();
            systems[typeof(InputSystem)].TurnOn();
            systems[typeof(CameraSystem)].TurnOn();
            systems[typeof(PlayerSystem)].TurnOn();
            systems[typeof(EnemySystem)].TurnOn();
            systems[typeof(WeaponSystem)].TurnOn();
            
        }

        #region 事件集

        #endregion
    }
}