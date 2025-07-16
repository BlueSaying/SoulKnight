using UnityEngine;

public class BadPistol : BasePlayerWeapon
{
    public BadPistol(GameObject gameObject, Character character, PlayerWeaponStaticAttr staticAttr) : base(gameObject, character, staticAttr) { }

    protected override void OnFire()
    {
        base.OnFire();

        Bullet_5 bullet = ItemFactory.Instance.CreatePlayerBullet(PlayerBulletType.Bullet_5, firePoint.transform.position, rotOrigin.transform.rotation) as Bullet_5;
        bullet.ManagedToController();
    }
}