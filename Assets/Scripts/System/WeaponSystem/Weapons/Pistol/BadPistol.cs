using UnityEngine;

public class BadPistol : Pistol
{
    public BadPistol(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_1);
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_5, shootPoint.transform.position, rotOrigin.transform.rotation, owner);
    }
}