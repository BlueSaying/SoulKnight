using System;

[Serializable]
public class EnemyStaticAttr : CharacterStaticAttr
{
    /// <summary>
    /// 敌人类型
    /// </summary>
    public EnemyType enemyType;

    /// <summary>
    /// 是否为精英怪
    /// </summary>
    public bool isElite;

    /// <summary>
    /// 敌人武器类型
    /// </summary>
    public EnemyWeaponType enemyWeaponType;

    public EnemyStaticAttr DeepCopy()
    {
        EnemyStaticAttr output = new EnemyStaticAttr();
        output.enemyType = enemyType;
        output.isElite = isElite;
        output.enemyWeaponType = enemyWeaponType;
        output.name = name;
        output.maxHP = maxHP;
        output.speed = speed;
        return output;
    }
}