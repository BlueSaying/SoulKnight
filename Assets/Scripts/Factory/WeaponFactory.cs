using UnityEngine;

public class WeaponFactory : Singleton<WeaponFactory>
{
    private WeaponFactory() { }

    // 给*character*角色添加一个*type*类型的武器并
    // 放于WeaponOriginPoint物体下，返回该武器
    public Weapon GetWeapon(WeaponModel model, Character character)
    {
        WeaponType type = model.staticAttr.weaponType;
        GameObject WeaponOriginPoint = UnityTools.Instance.GetTransformFromChildren(character.gameObject, "WeaponOriginPoint").gameObject;

        GameObject obj = Object.Instantiate(ResourcesLoader.Instance.LoadWeapon(type.ToString()), WeaponOriginPoint.transform);
        obj.name = type.ToString();

        obj.transform.localPosition = Vector3.zero;

        Weapon weapon = null;
        switch (type)
        {
            case WeaponType.BadPistol:
                weapon = new BadPistol(obj, character, model);
                break;
            case WeaponType.Ak47:
                weapon = new Ak47(obj, character, model);
                break;
            case WeaponType.Pike:
                weapon = new Pike(obj, character, model);
                break;
        }

        return weapon;
    }

    // 在地上生成武器
    public GameObject InstantiateWeapon(WeaponType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject weaponPrefab = ResourcesLoader.Instance.LoadWeapon(type.ToString());

        GameObject newWeapon;
        if (parent != null)
        {
            newWeapon = Object.Instantiate(weaponPrefab, position, quaternion, parent);
        }
        else
        {
            newWeapon = Object.Instantiate(weaponPrefab, position, quaternion);
        }

        newWeapon.name = type.ToString();
        newWeapon.AddComponent<PickUpableWeapon>();
        return newWeapon;
    }
}