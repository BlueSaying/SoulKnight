using UnityEngine;

public class Burn : Buff
{
    private float damageTimer = 0f;
    private const float PlayerDamageTime = 1f;
    private const float EnemyDamageTime = 0.5f;

    public Burn(float duration, Character owner) : base(duration, owner) { }

    protected override void OnInit()
    {
        base.OnInit();

        // 对敌人,被附加灼烧时立即受到3点火元素伤害
        if (owner is Enemy)
        {
            (owner as Enemy).TakeDamage(3, Color.red);
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
            (owner as Player).TakeDamage(1, Color.red);
        }
        else if (owner is Enemy && damageTimer >= EnemyDamageTime)
        {
            damageTimer -= EnemyDamageTime;
            (owner as Enemy).TakeDamage(3, Color.red);
        }
    }
}