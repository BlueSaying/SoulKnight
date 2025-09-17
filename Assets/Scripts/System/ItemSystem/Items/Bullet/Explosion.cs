using UnityEngine;
using System.Collections;
using Cinemachine;

/// <summary>
/// 爆炸
/// </summary>
public class Explosion : Bullet
{
    // VCM的脉冲源,用于相机抖动
    private CinemachineImpulseSource ImpulseSource => gameObject.GetComponent<CinemachineImpulseSource>();
    private const float shakeForce = 0.25f;

    public Explosion(GameObject gameObject, Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType)
        : base(gameObject, owner, damage, isCritical, bulletSpeed, buffType) { }

    protected override void OnHitObstacle()
    {
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_explode_big);

        // 摄像机震动
        ImpulseSource.GenerateImpulseWithForce(shakeForce);
    }

    protected override void OnHitEnemy(Enemy enemy)
    {
        Color damageColor = isCritical ? Color.yellow : Color.red;

        enemy.TakeDamage(damage, damageColor);
        enemy.AddBuff(buffType);

        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_explode_big);

        // 添加爆炸冲击力
        Vector2 dir = ((Vector2)enemy.transform.position - position).normalized;
        CoroutinePool.Instance.StartCoroutine(this, ExplosionMove(enemy.rb, dir));

        // 摄像机震动
        ImpulseSource.GenerateImpulseWithForce(shakeForce);
    }

    protected override void OnHitPlayer(Player player)
    {
        Color damageColor = isCritical ? Color.yellow : Color.red;

        player.TakeDamage(damage, damageColor);
        player.AddBuff(buffType);

        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_explode_big);

        // 添加爆炸冲击力
        Vector2 dir = ((Vector2)player.transform.position - position).normalized;
        CoroutinePool.Instance.StartCoroutine(this, ExplosionMove(player.rb, dir));

        // 摄像机震动
        ImpulseSource.GenerateImpulseWithForce(shakeForce);
    }

    private IEnumerator ExplosionMove(Rigidbody2D targetRB, Vector2 dir)
    {
        float timer = 0f;
        const float time = 0.1f;

        while (true)
        {
            timer += Time.fixedDeltaTime;
            if (timer > time) break;

            MoveManager.Move(targetRB, dir * 75f);
            yield return null;
        }
    }

    private void ShakeCamera()
    {
        switch (SceneFacade.Instance.GetActiveSceneName())
        {
            case SceneName.MainMenuScene:
                break;

            case SceneName.MiddleScene:
                break;

            case SceneName.BattleScene:
                break;
        }
    }
}