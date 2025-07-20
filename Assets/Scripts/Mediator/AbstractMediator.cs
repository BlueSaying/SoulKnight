using System.Collections.Generic;

public abstract class AbstractMediator
{
    private List<AbstractSystem> systems;

    public AbstractMediator()
    {
        systems = new List<AbstractSystem>();
    }

    public void RegisterSystem(AbstractSystem newSystem)
    {
        systems.Add(newSystem);
    }

    // NOTE:使用where对T进行泛型约束，使用where使得T只能是AbstractController或其子类
    // NOTE:使用is去判断controller的类型是不是T
    // NOTE:as可以将controller的类型转换为T，与强制类型转换的区别是，as在转换失败时返回null，而不抛出异常
    public T GetSystem<T>() where T : AbstractSystem
    {
        foreach (AbstractSystem system in systems)
        {
            if (system is T)
            {
                return system as T;
            }
        }

        return default;
    }
}