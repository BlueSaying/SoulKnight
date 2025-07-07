using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        objDic = new Dictionary<string, GameObject>();
    }

    // 用于储存已经加载过的武器
    private Dictionary<string, GameObject> objDic;

    private string weaponPath = "Prefabs/Weapon/";

    public GameObject GetWeapon(string name)
    {
        if(objDic.ContainsKey(name)) return objDic[name];

        GameObject newWeapon = Resources.LoadAll<GameObject>(weaponPath).Where(x => x.name == name).ToArray()[0];
        objDic.Add(name, newWeapon);
        return newWeapon;
    }
}