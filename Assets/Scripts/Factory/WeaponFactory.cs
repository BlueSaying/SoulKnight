using UnityEngine;

public enum PlayerWeaponType
{
    BadPistol

}

public class WeaponFactory
{
    private static WeaponFactory _instance;
    public static WeaponFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WeaponFactory();
            }
            return _instance;
        }
    }
    private WeaponFactory() { }

    public IPlayerWeapon GetPlayerWeapon(PlayerWeaponType type,ICharacter character)
    {
        GameObject GunOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint").gameObject;
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetWeapon(type.ToString()), GunOriginPoint.transform);
        obj.name = type.ToString();

        obj.transform.localPosition = Vector3.zero;

        IPlayerWeapon weapon = null;
        switch(type)
        {
            case PlayerWeaponType.BadPistol:
                weapon=new BadPistol(obj,character);
                break;
        }

        return weapon;
    }
}