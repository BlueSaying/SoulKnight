using System.Collections.Generic;

public class PlayerWeaponRepository
{
    // 储存所有角色武器的数据
    private List<PlayerWeaponModel> models;

    public PlayerWeaponRepository()
    {
        List<PlayerWeaponStaticAttr> playerWeaponStaticData = SOLoader.GetPlayerWeaponSO().attrs;

        models = new List<PlayerWeaponModel>();
        for (int i = 0; i < playerWeaponStaticData.Count; i++)
        {
            models.Add(new PlayerWeaponModel(playerWeaponStaticData[i]));
        }
    }

    public PlayerWeaponModel GetPlayerWeaponModel(PlayerWeaponType playerWeaponType)
    {
        foreach (var model in models)
        {
            if (model.staticAttr.playerWeaponType == playerWeaponType)
            {
                return model;
            }
        }

        return default;
    }
}
