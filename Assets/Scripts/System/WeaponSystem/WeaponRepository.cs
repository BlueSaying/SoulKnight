using System;
using System.Collections.Generic;

public class WeaponRepository
{
    // 储存所有角色武器的数据
    private Dictionary<WeaponCategory, List<WeaponModel>> models;

    public WeaponRepository()
    {
        models = new Dictionary<WeaponCategory, List<WeaponModel>>();

        foreach (WeaponCategory weaponCategory in Enum.GetValues(typeof(WeaponCategory)))
        {
            models.Add(weaponCategory, new List<WeaponModel>());

            switch (weaponCategory)
            {
                case WeaponCategory.Melee:
                    foreach (var attr in SOLoader.GetMeleeSO().attrs)
                    {
                        models[weaponCategory].Add(new MeleeModel(attr));
                    }
                    break;

                case WeaponCategory.Rifle:
                    foreach (var attr in SOLoader.GetRifleSO().attrs)
                    {
                        models[weaponCategory].Add(new RifleModel(attr));
                    }
                    break;

                case WeaponCategory.ShotGun:
                    foreach (var attr in SOLoader.GetShotGunSO().attrs)
                    {
                        models[weaponCategory].Add(new ShotGunModel(attr));
                    }
                    break;

                case WeaponCategory.Pistol:
                    foreach (var attr in SOLoader.GetPistolSO().attrs)
                    {
                        models[weaponCategory].Add(new PistolModel(attr));
                    }
                    break;

                case WeaponCategory.Strange:
                    foreach (var attr in SOLoader.GetStrangeSO().attrs)
                    {
                        models[weaponCategory].Add(new StrangeModel(attr));
                    }
                    break;

                case WeaponCategory.Bow:
                    foreach (var attr in SOLoader.GetBowSO().attrs)
                    {
                        models[weaponCategory].Add(new BowModel(attr));
                    }
                    break;

                case WeaponCategory.Staff:
                    foreach (var attr in SOLoader.GetStaffSO().attrs)
                    {
                        models[weaponCategory].Add(new StaffModel(attr));
                    }
                    break;
            }
        }
    }

    public WeaponModel GetWeaponModel(WeaponCategory weaponCategory, WeaponType weaponType)
    {
        foreach (var model in models[weaponCategory])
        {
            if (model.staticAttr.weaponType == weaponType)
            {
                return model;
            }
        }

        return default;
    }

    public WeaponModel GetWeaponModel(WeaponType weaponType)
    {
        foreach (var models in models.Values)
        {
            foreach (var model in models)
            {
                if (model.staticAttr.weaponType == weaponType)
                {
                    return model;
                }
            }
        }

        return default;
    }
}
