
using System;

[Serializable]
public abstract class CharacterStaticAttr
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public string name;

    /// <summary>
    /// 最大生命值
    /// </summary>
    public int maxHp;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float speed;
}