using System;
using System.Collections.Generic;

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        protected override void OnInit()
        {
            base.OnInit();

            systems.Add(typeof(ItemSystem), SystemRepository.Instance.GetSystem<ItemSystem>());
            systems.Add(typeof(InputSystem), SystemRepository.Instance.GetSystem<InputSystem>());
            systems.Add(typeof(PlayerSystem), SystemRepository.Instance.GetSystem<PlayerSystem>());
            systems.Add(typeof(EnemySystem), SystemRepository.Instance.GetSystem<EnemySystem>());
            systems.Add(typeof(WeaponSystem), SystemRepository.Instance.GetSystem<WeaponSystem>());
            systems.Add(typeof(CameraSystem), SystemRepository.Instance.GetSystem<CameraSystem>());
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            systems[typeof(InputSystem)].TurnOn();
            systems[typeof(CameraSystem)].TurnOn();
            systems[typeof(PlayerSystem)].TurnOn();

            EventCenter.Instance.RegisterEvent(EventType.OnSelectSkinComplete, false, OnSelectSkinComplete);
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
