using UnityEngine;

public class StrongBow : Bow
{
    public StrongBow(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();

        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_rocket);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
        var damageInfo = CalcDamageInfo();
        int damage = damageInfo.damage;
        bool isCritical = damageInfo.isCritical;

        ItemFactory.Instance.CreateBullet(BulletType.Arrow, shootPoint.transform.position, quaternion,
            owner, damage, isCritical, BulletSpeed, isCritical ? BuffType : BuffType.None);
    }
}