using System;
using UnityEngine;

public static class WeaponFactory
{

    // 给*character*角色添加一个*type*类型的武器并
    // 放于WeaponOriginPoint物体下，返回该武器
    public static Weapon GetWeapon(WeaponModel model, Character owner)
    {
        WeaponType type = model.staticAttr.weaponType;
        GameObject WeaponOriginPoint = UnityTools.GetTransformFromChildren(owner.gameObject, "WeaponOriginPoint").gameObject;

        GameObject obj = UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadWeapon(type.ToString()), WeaponOriginPoint.transform);
        obj.name = type.ToString();
        obj.transform.localPosition = Vector3.zero;

        Type typeofWeapon = Type.GetType(type.ToString());
        Weapon newWeapon = Activator.CreateInstance(typeofWeapon, new object[] { obj, owner, model }) as Weapon;
        newWeapon.isPickUp = true;

        return newWeapon;
    }

    // 在地上生成武器
    public static GameObject InstantiateWeapon(WeaponType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject weaponPrefab = ResourcesLoader.Instance.LoadWeapon(type.ToString());

        GameObject newWeapon;
        if (parent != null)
        {
            newWeapon = UnityEngine.Object.Instantiate(weaponPrefab, position, quaternion, parent);
        }
        else
        {
            newWeapon = UnityEngine.Object.Instantiate(weaponPrefab, position, quaternion);
        }

        newWeapon.name = type.ToString();
        newWeapon.AddComponent<PickUpableWeapon>();
        return newWeapon;
    }
}