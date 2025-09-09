using System;

[Serializable]
public class ShotGunStaticAttr : WeaponStaticAttr
{
    /// <summary>
    /// 霰弹枪弹道之间的夹角
    /// </summary>
    public float angle;

    /// <summary>
    /// 霰弹枪弹丸数
    /// </summary>
    public int bulletCount;
}