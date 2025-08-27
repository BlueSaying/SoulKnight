using UnityEngine;
public class DesertEagle : Pistol
{
    public DesertEagle(UnityEngine.GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-scatterRate / 2.0f, scatterRate / 2.0f));
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_130, shootPoint.transform.position, quaternion, owner, damage, bulletSpeed);
    }
}