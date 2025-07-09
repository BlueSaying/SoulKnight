using System;
using System.Reflection;

public abstract class Singleton<T> where T : Singleton<T>
{
    protected Singleton() { }

    protected static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // 先获取所有非public构造方法
                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                // 从ctors中获取无参的构造方法
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                {
                    throw new Exception("Non-public ctor() not  found!");
                }
                _instance = ctor.Invoke(null) as T;
            }
            return _instance;
        }
    }
}