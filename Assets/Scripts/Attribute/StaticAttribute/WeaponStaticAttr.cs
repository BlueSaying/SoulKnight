using System;

[Serializable]
public class WeaponStaticAttr
{
    /// <summary>
    /// 武器可施加的buff
    /// </summary>
    public BuffType buffType;

    /// <summary>
    /// 武器大类
    /// </summary>
    public WeaponCategory weaponCategory;

    /// <summary>
    /// 射速
    /// </summary>
    public float fireRate;

    /// <summary>
    /// 子弹速度
    /// </summary>
    public float speed;
}