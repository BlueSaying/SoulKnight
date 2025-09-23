
using UnityEngine;

public class AssaultRifle : Rifle
{
    public AssaultRifle(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
        var damageInfo = CalcDamageInfo();
        int damage = damageInfo.damage;
        bool isCritical = damageInfo.isCritical;
        BuffType buffType = isCritical ? BuffType : BuffType.None;

        ItemFactory.Instance.CreateBullet(BulletType.Bullet_5, shootPoint.transform.position, quaternion,
            owner, damage, isCritical, BulletSpeed, buffType);
    }
}