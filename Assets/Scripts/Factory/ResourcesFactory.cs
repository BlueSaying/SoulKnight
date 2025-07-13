using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 专门用来管理从Resources文件加载东西的类
public class ResourcesFactory
{
    private static ResourcesFactory _instance;
    public static ResourcesFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ResourcesFactory();
            }
            return _instance;
        }
    }
    private ResourcesFactory()
    {
        weaponDic = new Dictionary<string, GameObject>();
    }

    // 用于储存已经加载过的武器
    private Dictionary<string, GameObject> weaponDic;
    private string weaponPath = "Prefabs/Weapon/";

    // 角色皮肤路径
    private string playerSkinPath = "Animation/Characters/Players/";

    // 数据路径
    private string dataPath = "Datas/";

    public GameObject GetWeapon(string name)
    {
        if (weaponDic.ContainsKey(name)) return weaponDic[name];

        // NOTE:此处可优化，因为每次都要遍历整个文件
        GameObject newWeapon = Resources.LoadAll<GameObject>(weaponPath).Where(x => x.name == name).ToArray()[0];
        weaponDic.Add(name, newWeapon);
        return newWeapon;
    }

    public RuntimeAnimatorController GetPlayerSkin(string name)
    {
        return Resources.LoadAll<RuntimeAnimatorController>(playerSkinPath + name).Where(x => x.name == name).ToArray()[0];
    }

    // 读取SO数据
    public T GetScriptableObject<T>() where T : ScriptableObject
    {
        Type type = typeof(T);
        string path = dataPath;

        if (type == typeof(PlayerSO))
        {
            path += "PlayerData";
        }
        if (type == typeof(PlayerSkinSO))
        {
            path += "PlayerSkinData";
        }

        return Resources.Load<T>(path);
    }
}