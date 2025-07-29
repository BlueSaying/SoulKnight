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

            systems=new Dictionary<Type, BaseSystem>();
            
            systems.Add(typeof(ItemSystem),SystemRepository.Instance.GetSystem<ItemSystem>());
            systems.Add(typeof(InputSystem),SystemRepository.Instance.GetSystem<InputSystem>());
            systems.Add(typeof(PlayerSystem),SystemRepository.Instance.GetSystem<PlayerSystem>());
            systems.Add(typeof(EnemySystem),SystemRepository.Instance.GetSystem<EnemySystem>());
            systems.Add(typeof(WeaponSystem),SystemRepository.Instance.GetSystem<WeaponSystem>());
            systems.Add(typeof(CameraSystem),SystemRepository.Instance.GetSystem<CameraSystem>());
            systems.Add(typeof(AudioSystem),SystemRepository.Instance.GetSystem<AudioSystem>());

            EventCenter.Instance.ReigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
                systems[typeof(PlayerSystem)].TurnOnController();
            });

            // HACK
            systems[typeof(EnemySystem)].TurnOnController();
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();

            foreach (var system in systems.Values)
            {
                system.GameUpdate();
            }
        }
    }
}
