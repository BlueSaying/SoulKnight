using UnityEngine;

public class Ak47 : PlayerWeapon
{
    public Ak47(GameObject gameObject, Character character, PlayerWeaponStaticAttr staticAttr) : base(gameObject, character, staticAttr) { }

    protected override void OnFire()
    {
        base.OnFire();

        Bullet_34 bullet = ItemFactory.Instance.CreatePlayerBullet(PlayerBulletType.Bullet_34, firePoint.transform.position, rotOrigin.transform.rotation) as Bullet_34;
        bullet.ManagedToController();
    }
}