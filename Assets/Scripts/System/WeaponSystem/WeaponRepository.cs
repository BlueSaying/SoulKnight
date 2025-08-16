using System.Collections.Generic;

public class WeaponRepository
{
    // 储存所有角色武器的数据
    private List<WeaponModel> models;

    public WeaponRepository()
    {
        List<WeaponStaticAttr> weaponStaticData = SOLoader.GetWeaponSO().attrs;

        models = new List<WeaponModel>();
        for (int i = 0; i < weaponStaticData.Count; i++)
        {
            models.Add(new WeaponModel(weaponStaticData[i]));
        }
    }

    public WeaponModel GetWeaponModel(WeaponType weaponType)
    {
        foreach (var model in models)
        {
            if (model.staticAttr.weaponType == weaponType)
            {
                return model;
            }
        }

        return default;
    }
}
