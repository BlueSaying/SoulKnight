//using System.Collections.Generic;

//public abstract class AbstractMediator
//{
//    private List<BaseSystem> systems;

//    public AbstractMediator()
//    {
//        systems = new List<BaseSystem>();
//    }

//    public void RegisterSystem(BaseSystem newSystem)
//    {
//        systems.Add(newSystem);
//    }

//    // NOTE:使用where对T进行泛型约束，使用where使得T只能是AbstractController或其子类
//    // NOTE:使用is去判断controller的类型是不是T
//    // NOTE:as可以将controller的类型转换为T，与强制类型转换的区别是，as在转换失败时返回null，而不抛出异常
//    public T GetSystm<T>() where T : BaseSystem
//    {
//        foreach (BaseSystem system in systems)
//        {
//            if (system is T)
//            {
//                return system as T;
//            }
//        }

//        return default;
//    }
//}