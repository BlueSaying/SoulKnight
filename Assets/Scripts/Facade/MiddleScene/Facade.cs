using System;
using System.Collections.Generic;

namespace MiddleScene
{
    public class Facade : AbstractFacade
    {
        // 当前场景需要的Systems
        private Dictionary<Type, BaseSystem> systems;

        protected override void OnInit()
        {
            base.OnInit();

            systems = new Dictionary<Type, BaseSystem>();

            systems.Add(typeof(ItemSystem), SystemRepository.Instance.GetSystem<ItemSystem>());
            systems.Add(typeof(InputSystem), SystemRepository.Instance.GetSystem<InputSystem>());
            systems.Add(typeof(PlayerSystem), SystemRepository.Instance.GetSystem<PlayerSystem>());
            systems.Add(typeof(EnemySystem), SystemRepository.Instance.GetSystem<EnemySystem>());
            systems.Add(typeof(WeaponSystem), SystemRepository.Instance.GetSystem<WeaponSystem>());
            systems.Add(typeof(CameraSystem), SystemRepository.Instance.GetSystem<CameraSystem>());
            systems.Add(typeof(AudioSystem), SystemRepository.Instance.GetSystem<AudioSystem>());
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            systems[typeof(InputSystem)].TurnOn();
            systems[typeof(CameraSystem)].TurnOn();
            systems[typeof(PlayerSystem)].TurnOn();
            systems[typeof(AudioSystem)].TurnOn();

            EventCenter.Instance.RegisterEvent(EventType.OnSelectSkinComplete, false, OnSelectSkinComplete);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            foreach (var system in systems.Values)
            {
                system.GameUpdate();
            }
        }

        protected override void OnExit()
        {
            base.OnExit();

            foreach (var system in systems.Values)
            {
                system.TurnOff();
            }

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
