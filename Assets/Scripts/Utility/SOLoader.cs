using UnityEngine;

public static class SOLoader
{
    // 数据
    private static readonly string dataPath = "Datas/";

    private static readonly string PlayerDataPath = "PlayerData";
    private static readonly string PlayerSkinDataPath = "PlayerSkinData";
    private static readonly string EnemyDataPath = "EnemyData";
    private static readonly string levelDataPath = "Level/LevelData_";

    private static readonly string MeleeDataPath = "Weapons/MeleeData";
    private static readonly string PistolDataPath = "Weapons/PistolData";
    private static readonly string RifleDataPath = "Weapons/RifleData";
    private static readonly string ShotGunDataPath = "Weapons/ShotGunData";
    private static readonly string StrangeDataPath = "Weapons/StrangeData";
    private static readonly string BowDataPath = "Weapons/BowData";
    private static readonly string StaffDataPath = "Weapons/StaffData";

    public static PlayerSO GetPlayerSO()
    {
        return Resources.Load<PlayerSO>(dataPath + PlayerDataPath);
    }

    public static PlayerSkinSO GetPlayerSkinSO()
    {
        return Resources.Load<PlayerSkinSO>(dataPath + PlayerSkinDataPath);
    }

    public static EnemySO GetEnemySO()
    {
        return Resources.Load<EnemySO>(dataPath + EnemyDataPath);
    }

    public static LevelSO GetLevelSO(LevelType levelType)
    {
        return Resources.Load<LevelSO>(dataPath + levelDataPath + levelType.ToString());
    }

    #region 武器SO
    public static MeleeSO GetMeleeSO()
    {
        return Resources.Load<MeleeSO>(dataPath + MeleeDataPath);
    }

    public static PistolSO GetPistolSO()
    {
        return Resources.Load<PistolSO>(dataPath + PistolDataPath);
    }

    public static RifleSO GetRifleSO()
    {
        return Resources.Load<RifleSO>(dataPath + RifleDataPath);
    }

    public static ShotGunSO GetShotGunSO()
    {
        return Resources.Load<ShotGunSO>(dataPath + ShotGunDataPath);
    }

    public static StrangeSO GetStrangeSO()
    {
        return Resources.Load<StrangeSO>(dataPath + StrangeDataPath);
    }

    public static BowSO GetBowSO()
    {
        return Resources.Load<BowSO>(dataPath + BowDataPath);
    }

    public static StaffSO GetStaffSO()
    {
        return Resources.Load<StaffSO>(dataPath + StaffDataPath);
    }
    #endregion
}
