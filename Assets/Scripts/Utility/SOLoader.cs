using System;
using UnityEngine;

public static class SOLoader
{
    // 数据
    private static string dataPath = "Datas/";

    private static string playerDataPath = "PlayerData";
    private static string playerSkinDataPath = "PlayerSkinData";
    private static string weaponDataPath = "WeaponData";
    private static string enemyDataPath = "EnemyData";
    private static string levelDataPath = "Level/LevelData_";

    public static PlayerSO GetPlayerSO()
    {
        return Resources.Load<PlayerSO>(dataPath + playerDataPath);
    }

    public static PlayerSkinSO GetPlayerSkinSO()
    {
        return Resources.Load<PlayerSkinSO>(dataPath + playerSkinDataPath);
    }

    public static WeaponSO GetWeaponSO()
    {
        return Resources.Load<WeaponSO>(dataPath + weaponDataPath);
    }

    public static EnemySO GetEnemySO()
    {
        return Resources.Load<EnemySO>(dataPath + enemyDataPath);
    }

    public static LevelSO GetLevelSO(LevelType levelType)
    {
        return Resources.Load<LevelSO>(dataPath + levelDataPath + levelType.ToString());
    }
}
