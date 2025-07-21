using System;

/// <summary>
/// 玩家武器静态属性
/// </summary>
[Serializable]
public class PlayerWeaponStaticAttr : WeaponStaticAttr
{
    /// <summary>
    /// 武器类型
    /// </summary>
    public PlayerWeaponType playerWeaponType;

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
}