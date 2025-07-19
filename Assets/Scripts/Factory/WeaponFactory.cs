using UnityEngine;

public class WeaponFactory : Singleton<WeaponFactory>
{
    private WeaponFactory() { }

    // 给*character*角色添加一个*type*类型的武器并
    // 放于GunOriginPoint物体下，返回该武器
    public PlayerWeapon GetPlayerWeapon(PlayerWeaponType type, Character character)
    {
        GameObject GunOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint").gameObject;
        PlayerWeaponStaticAttr staticAttr = WeaponCommand.Instance.GetPlayerWeaponStaticAttr(type);

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

    // 在地上生成武器
    public GameObject InstantiatePlayerWeapon(PlayerWeaponType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject playerWeaponPrefab = ResourcesFactory.Instance.GetWeapon(type.ToString());

        GameObject newPlayerWeapon;
        if (parent != null)
        {
            newPlayerWeapon = Object.Instantiate(playerWeaponPrefab, position, quaternion, parent);
        }
        else
        {
            newPlayerWeapon = Object.Instantiate(playerWeaponPrefab, position, quaternion);
        }

        newPlayerWeapon.name = type.ToString();
        newPlayerWeapon.AddComponent<PickUpableWeapon>();
        return newPlayerWeapon;
    }
}