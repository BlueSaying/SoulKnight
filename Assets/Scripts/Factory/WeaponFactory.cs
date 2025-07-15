using UnityEngine;

public enum PlayerWeaponType
{
    BadPistol,
    Ak47,
    H2O,
    P250Pistol,
    Furnace,
    Icebreaker,
    PKP,
    AK47,
    UZI,
    SnowFoxL,
    AssaultRifle,
    MissileBattery,
    TheCode,
    TheCodePlus,
    CrimsonWineGlass,
    DesertEagle,
    GrenadePistol,
    NextNextNextGenSMG,
    EagleOfIceAndFire,
    DormantBubbleMachine,
    Basketball,
    Bow,
    Shower,
    GatlingGun,
    DoubleBladeSword,
    WoodenCross,
    BlueFireGatling,
    RainbowGatling,
}

public class WeaponFactory:Singleton<WeaponFactory>
{
    private WeaponFactory() { }

    // 给*character*角色添加一个*type*类型的武器并
    // 放于GunOriginPoint物体下，返回该武器
    public IPlayerWeapon GetPlayerWeapon(PlayerWeaponType type, ICharacter character)
    {
        GameObject GunOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint").gameObject;
        PlayerWeaponStaticAttr staticAttr = WeaponCommand.Instance.GetPlayerWeaponStaticAttr(type);
        // TODO:应该设置预制件中无pickupable脚本，仅在生成武器时添加pickupable脚本
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetWeapon(type.ToString()), GunOriginPoint.transform);
        obj.name = type.ToString();

        obj.transform.localPosition = Vector3.zero;

        IPlayerWeapon weapon = null;
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