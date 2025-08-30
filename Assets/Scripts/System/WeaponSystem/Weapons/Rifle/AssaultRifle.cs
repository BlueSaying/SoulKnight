
using UnityEngine;

public class AssaultRifle : Rifle
{
    public AssaultRifle(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
        int criticalRate = CriticalRate + (owner is Player player ? player.critical : 0);
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_5, shootPoint.transform.position, quaternion, owner, Damage, criticalRate, BulletSpeed);
    }
}