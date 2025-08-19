using UnityEngine;

/// <summary>
/// 可被攻击的
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// 对角色造成伤害
    /// </summary>
    /// <param name="damage">伤害量</param>
    void TakeDamage(int damage, Color damageColor);

    /// <summary>
    /// 令角色死亡
    /// </summary>
    void Die();
}