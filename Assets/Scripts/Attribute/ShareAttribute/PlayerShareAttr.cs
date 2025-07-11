using System;

[Serializable]
public class PlayerShareAttr : CharacterShareAttr
{
    // 角色类型
    public PlayerType playerType;

    // 默认武器
    public PlayerWeaponType defaultWeaponType;

    // 护甲值
    public int armor;

    // 能量值
    public int energy;

    // 暴击
    public int critical;

    // 手刀伤害
    public int handAttackDamage;

    // 开始战斗的移动速度
    public float fightingSpeed;

    // 进入战斗场景但是没开始战斗的移动速度
    public float finishFightingSpeed;

    // 护甲恢复一格所需时间
    public float armorRecoveryTime;

    // 受到伤害后多长时间开始回复护甲
    public float hurtArmorRecoveryTime;

    // 每次受到伤害的无敌时间
    public float hurtInvincibleTime;
}