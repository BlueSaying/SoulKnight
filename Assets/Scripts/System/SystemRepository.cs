using System;
using System.Collections.Generic;

public enum SystemType
{
    BuffSystem,
    CameraSystem,
    EnemySystem,
    InputSystem,
    ItemSystem,
    MapSystem,
    PlayerSystem,
    WeaponSystem,
}

public class SystemRepository : Singleton<SystemRepository>
{
    private Dictionary<Type, BaseSystem> systemDic;

    private SystemRepository()
    {
        systemDic = new Dictionary<Type, BaseSystem>();

        foreach (var systemName in Enum.GetNames(typeof(SystemType)))
        {
            Type systemType = Type.GetType(systemName);
            BaseSystem system = Activator.CreateInstance(systemType) as BaseSystem;
            systemDic.Add(systemType, system);
        }
    }

    public T GetSystem<T>() where T : BaseSystem
    {
        if (systemDic.TryGetValue(typeof(T), out BaseSystem value)) return value as T;

        return default;
    }
}
