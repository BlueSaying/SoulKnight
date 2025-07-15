using UnityEngine;

public class BadPistol : IPlayerWeapon
{
    public BadPistol(GameObject gameObject, ICharacter character, PlayerWeaponStaticAttr staticAttr) : base(gameObject, character, staticAttr) { }

    protected override void OnFire()
    {
        base.OnFire();

        Bullet_5 bullet = ItemFactory.Instance.GetPlayerBullet(PlayerBulletType.Bullet_5, firePoint.transform.position, rotOrigin.transform.rotation) as Bullet_5;
        bullet.ManagedToController();
    }
}