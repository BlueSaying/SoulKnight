using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelContainer
{
    private static ModelContainer _instance;
    public static ModelContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ModelContainer();
            }
            return _instance;
        }
    }
    private Dictionary<Type, AbstractModel> modelDic;

    private ModelContainer()
    {
        modelDic = new Dictionary<Type, AbstractModel>();
        modelDic.Add(typeof(SceneModel), new SceneModel());
    }

    public T GetModel<T>() where T : AbstractModel
    {
        if (modelDic.ContainsKey(typeof(T)))
        {
            return modelDic[typeof(T)] as T;
        }

        return default;
    }
}