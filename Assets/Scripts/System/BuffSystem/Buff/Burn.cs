using UnityEngine;

public class Burn : Buff
{
    private float damageTimer = 0f;

    private const float PlayerDamageTime = 1f;
    private const int PlayerDamage = 1;

    private const float EnemyDamageTime = 0.5f;
    private const int EnemyDamage = 3;

    // 燃烧伤害为橙色
    private static readonly Color damageColor = new Color(1f, 0.6f, 0f);

    public Burn(Character owner) : base(2f, owner) { }

    protected override void OnInit()
    {
        base.OnInit();

        // 对敌人,被附加灼烧时立即受到一次伤害
        if (owner is Enemy)
        {
            (owner as Enemy).TakeDamage(EnemyDamage, damageColor);
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
            (owner as Player).TakeDamage(PlayerDamage, damageColor);
        }
        else if (owner is Enemy && damageTimer >= EnemyDamageTime)
        {
            damageTimer -= EnemyDamageTime;
            (owner as Enemy).TakeDamage(EnemyDamage, damageColor);
        }
    }
}