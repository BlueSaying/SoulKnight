using UnityEditor.U2D.Aseprite;

public class WeaponCommand : Singleton<WeaponCommand>
{
    private WeaponModel weaponModel;

    private WeaponCommand()
    {
        weaponModel = ModelContainer.Instance.GetModel<WeaponModel>();
    }

    public PlayerWeaponStaticAttr GetPlayerWeaponStaticAttr(PlayerWeaponType weaponType)
    {
        foreach (var attr in weaponModel.datas)
        {
            if (attr.weaponType == weaponType)
            {
                return attr;
            }
        }

        return default;
    }
}