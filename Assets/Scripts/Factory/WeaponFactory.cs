using UnityEngine;

public class WeaponFactory:Singleton<WeaponFactory>
{
    private WeaponFactory() { }

    // 给*character*角色添加一个*type*类型的武器并
    // 放于GunOriginPoint物体下，返回该武器
    public PlayerWeapon GetPlayerWeapon(PlayerWeaponType type, Character character)
    {
        GameObject GunOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint").gameObject;
        PlayerWeaponStaticAttr staticAttr = WeaponCommand.Instance.GetPlayerWeaponStaticAttr(type);
        // TODO:应该设置预制件中无pickupable脚本，仅在生成武器时添加pickupable脚本
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetWeapon(type.ToString()), GunOriginPoint.transform);
        obj.name = type.ToString();

        obj.transform.localPosition = Vector3.zero;

        PlayerWeapon weapon = null;
        switch (type)
        {
            case PlayerWeaponType.BadPistol:
                weapon = new BadPistol(obj, character, staticAttr);
                break;
            case PlayerWeaponType.Ak47:
                weapon = new Ak47(obj, character, staticAttr);
                break;
        }

        return weapon;
    }
}

public class CopyOfWeaponFactory : Singleton<CopyOfWeaponFactory>
{
    private CopyOfWeaponFactory() { }

    // 给*character*角色添加一个*type*类型的武器并
    // 放于GunOriginPoint物体下，返回该武器
    public PlayerWeapon GetPlayerWeapon(PlayerWeaponType type, Character character)
    {
        GameObject GunOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint").gameObject;
        PlayerWeaponStaticAttr staticAttr = WeaponCommand.Instance.GetPlayerWeaponStaticAttr(type);
        // TODO:应该设置预制件中无pickupable脚本，仅在生成武器时添加pickupable脚本
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetWeapon(type.ToString()), GunOriginPoint.transform);
        obj.name = type.ToString();

        obj.transform.localPosition = Vector3.zero;

        PlayerWeapon weapon = null;
        switch (type)
        {
            case PlayerWeaponType.BadPistol:
                weapon = new BadPistol(obj, character, staticAttr);
                break;
            case PlayerWeaponType.Ak47:
                weapon = new Ak47(obj, character, staticAttr);
                break;
        }

        return weapon;
    }
}