using UnityEngine;

public class CompositeBow : Bow
{
    public CompositeBow(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();

        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_rocket);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
        int damage = Mathf.RoundToInt(Mathf.Lerp(Damage, ChargingDamage, chargingTimer / ChargingTime));
        ItemFactory.Instance.CreateBullet(BulletType.Arrow, shootPoint.transform.position, quaternion, owner, damage, BulletSpeed);
    }
}