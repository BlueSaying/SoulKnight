using UnityEngine;

/// <summary>
/// 爆炸
/// </summary>
public class Explosion : Bullet
{
    public Explosion(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_explode_big);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        Color damageColor = isCritical ? Color.yellow : Color.red;

        enemy.TakeDamage(damage, damageColor);
        enemy.AddBuff(buffType);

        // HACK
        enemy.rb.AddForce(((Vector2)enemy.transform.position - position).normalized * 100f);

        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_explode_big);
    }

    protected override void OnHitPlayer(Player player)
    {
        Color damageColor = isCritical ? Color.yellow : Color.red;

        player.TakeDamage(damage, damageColor);
        player.AddBuff(buffType);

        // HACK
        player.rb.AddForce(((Vector2)player.transform.position - position).normalized * 100f);

        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_explode_big);
    }
}