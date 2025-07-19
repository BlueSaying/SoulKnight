using UnityEngine;

public class BadPistol : PlayerWeapon
{
    public BadPistol(GameObject gameObject, Character character, PlayerWeaponStaticAttr staticAttr) : base(gameObject, character, staticAttr) { }

    protected override void OnFire()
    {
        base.OnFire();

        GameMediator.Instance.GetSystem<MusicSystem>().PlayAudio(AudioType.fx_gun_1);
        Bullet_5 bullet = ItemFactory.Instance.CreatePlayerBullet(PlayerBulletType.Bullet_5, firePoint.transform.position, rotOrigin.transform.rotation) as Bullet_5;
        bullet.ManagedToController();
    }
}