using UnityEngine;

public class Poisoning : Buff
{
    private float damageTimer = 0f;

    private const float speedDecrease = 0.3f;

    private const float PlayerDamageTime = 2f;
    private const int PlayerDamage = 1;

    private const float EnemyDamageTime = 0.5f;
    private const int EnemyDamage = 1;
    private static readonly Color DamageColor = Color.green;

    public Poisoning(Character owner) : base(5f, owner) { }

    protected override void OnInit()
    {
        base.OnInit();

        // 瞬间减速
        owner.CurSpeed.AddPercentModifier(-speedDecrease);

        // 对敌人,被附加中毒时立即受到一次伤害伤害
        if (owner is Enemy)
        {
            (owner as Enemy).TakeDamage(EnemyDamage, DamageColor);
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        damageTimer += Time.deltaTime;

        // 根据角色类型确定逻辑
        if (owner is Player && damageTimer >= PlayerDamageTime)
        {
            damageTimer -= PlayerDamageTime;
            (owner as Player).TakeDamage(PlayerDamage, DamageColor);
        }
        else if (owner is Enemy && damageTimer >= EnemyDamageTime)
        {
            damageTimer -= EnemyDamageTime;
            (owner as Enemy).TakeDamage(EnemyDamage, DamageColor);
        }
    }

    public override void EndBuff()
    {
        base.EndBuff();

        // 恢复减速
        owner.CurSpeed.AddPercentModifier(speedDecrease);
    }
}