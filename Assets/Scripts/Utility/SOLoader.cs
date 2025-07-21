using System;
using UnityEngine;

public class SOLoader : Singleton<SOLoader>
{
    private SOLoader() { }

    // 数据
    private string dataPath = "Datas/";

    // 读取SO数据
    public T LoadScriptableObject<T>() where T : ScriptableObject
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
        if (type == typeof(EnemySO))
        {
            path += "EnemyData";
        }

        return Resources.Load<T>(path);
    }
}
