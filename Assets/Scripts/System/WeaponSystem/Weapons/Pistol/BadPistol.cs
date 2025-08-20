using UnityEngine;

public class BadPistol : Pistol
{
    public BadPistol(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-model.staticAttr.scatterRate / 2.0f, model.staticAttr.scatterRate / 2.0f));
        ItemFactory.Instance.CreateBullet(BulletType.Bullet_5, shootPoint.transform.position, quaternion, owner, model.staticAttr.damage);
    }
}