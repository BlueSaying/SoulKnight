using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMediator
{
    private List<AbstractController> controllers;

    public AbstractMediator()
    {
        controllers = new List<AbstractController>();
    }

    public void RegisterController(AbstractController controller)
    {
        controllers.Add(controller);
    }

    // NOTE:使用where对T进行泛型约束，使用where使得T只能是AbstractController或其子类
    // NOTE:使用is去判断controller的类型是不是T
    // NOTE:as可以将controller的类型转换为T，与强制类型转换的区别是，as在转换失败时返回null，而不抛出异常
    public T GetController<T>() where T : AbstractController
    {
        foreach (AbstractController controller in controllers)
        {
            if (controller is T)
            {
                return controller as T;
            }
        }

        return default;
    }
}