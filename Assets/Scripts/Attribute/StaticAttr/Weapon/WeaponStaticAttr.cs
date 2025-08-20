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
    /// 武器名称
    /// </summary>
    public WeaponType weaponType;

    /// <summary>
    /// 品质
    /// </summary>
    public QualityType qualityType;

    /// <summary>
    /// 武器伤害
    /// </summary>
    public int damage;

    /// <summary>
    /// 能量消耗
    /// </summary>
    public int energyCost;

    /// <summary>
    /// 暴击率
    /// </summary>
    public int criticalRate;

    /// <summary>
    /// 散射率
    /// </summary>
    public int scatterRate;

    /// <summary>
    /// 弹道之间的夹角(仅霰弹枪)
    /// </summary>
    public int angle;

    /// <summary>
    /// 移速降低量
    /// </summary>
    public float speedDecrease;

    /// <summary>
    /// 射速
    /// </summary>
    public float fireRate;

    /// <summary>
    /// 子弹速度
    /// </summary>
    public float bulletSpeed;
}