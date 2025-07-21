using UnityEngine;

public class WeaponFactory : Singleton<WeaponFactory>
{
    private WeaponFactory() { }

    // 给*character*角色添加一个*type*类型的武器并
    // 放于GunOriginPoint物体下，返回该武器
    public PlayerWeapon GetPlayerWeapon(PlayerWeaponModel model, Character character)
    {
        PlayerWeaponType type = model.staticAttr.playerWeaponType;
        GameObject GunOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "GunOriginPoint").gameObject;        

        GameObject obj = Object.Instantiate(ResourcesLoader.Instance.LoadWeapon(type.ToString()), GunOriginPoint.transform);
        obj.name = type.ToString();

        obj.transform.localPosition = Vector3.zero;

        PlayerWeapon weapon = null;
        switch (type)
        {
            case PlayerWeaponType.BadPistol:
                weapon = new BadPistol(obj, character, model);
                break;
            case PlayerWeaponType.Ak47:
                weapon = new Ak47(obj, character, model);
                break;
        }

        return weapon;
    }

    // 在地上生成武器
    public GameObject InstantiatePlayerWeapon(PlayerWeaponType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject playerWeaponPrefab = ResourcesLoader.Instance.LoadWeapon(type.ToString());

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