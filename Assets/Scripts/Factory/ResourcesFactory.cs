using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Reporting;
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
    private string weaponPath = "Prefabs/Weapons/";

    // 子弹路径
    private string bulletPath = "Prefabs/Bullets/";

    // 特效路径
    private string effectPath = "Prefabs/Effects/";

    // 角色皮肤路径
    private string playerSkinPath = "Animation/Characters/Players/";

    // 数据路径
    private string dataPath = "Datas/";

    public GameObject GetWeapon(string weaponName)
    {
        if (weaponDic.ContainsKey(weaponName)) return weaponDic[weaponName];

        // NOTE:此处可优化，因为每次都要遍历整个文件
        GameObject newWeapon = Resources.LoadAll<GameObject>(weaponPath).Where(x => x.name == weaponName).ToArray()[0];
        weaponDic.Add(weaponName, newWeapon);
        return newWeapon;
    }

    public GameObject GetBullet(string bulletName)
    {
        return Resources.LoadAll<GameObject>(bulletPath).Where(x => x.name == bulletName).ToArray()[0];
    }

    public GameObject GetEffect(string effectName)
    {
        return Resources.LoadAll<GameObject>(effectPath).Where(x => x.name == effectName).ToArray()[0];
    }

    public RuntimeAnimatorController GetPlayerSkin(string playerSkinName)
    {
        return Resources.LoadAll<RuntimeAnimatorController>(playerSkinPath + playerSkinName).Where(x => x.name == playerSkinName).ToArray()[0];
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
        if (type == typeof(PlayerWeaponSO))
        {
            path += "PlayerWeaponData";
        }

        return Resources.Load<T>(path);
    }
}