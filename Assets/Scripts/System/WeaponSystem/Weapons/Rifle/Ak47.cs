using UnityEngine;

public class AK47 : Rifle
{
    public AK47(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_1);
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_34, shootPoint.transform.position, rotOrigin.transform.rotation, owner, model.staticAttr.damage);
    }
}