using UnityEngine;

public class AK47 : Rifle
{
    public AK47(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_34, shootPoint.transform.position, quaternion, owner, Damage, BulletSpeed);
    }
}