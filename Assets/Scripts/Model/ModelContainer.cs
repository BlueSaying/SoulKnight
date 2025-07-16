using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelContainer : Singleton<ModelContainer>
{
    private Dictionary<Type, AbstractModel> modelDic;

    private ModelContainer()
    {
        modelDic = new Dictionary<Type, AbstractModel>();

        // NOTE:在此处添加新Model
        AddModel(new SceneModel());
        AddModel(new PlayerModel());
        AddModel(new PlayerSkinModel());
        AddModel(new WeaponModel());
        AddModel(new EnemyModel());
    }

    public T GetModel<T>() where T : AbstractModel
    {
        if (modelDic.ContainsKey(typeof(T)))
        {
            return modelDic[typeof(T)] as T;
        }

        return default;
    }

    private void AddModel<T>(T model) where T : AbstractModel
    {
        modelDic.Add(typeof(T), model);
    }
}