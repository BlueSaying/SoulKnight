using UnityEngine;

public class Ak47 : Rifle
{
    public Ak47(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_1);
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_34, shootPoint.transform.position, rotOrigin.transform.rotation, owner);
    }
}