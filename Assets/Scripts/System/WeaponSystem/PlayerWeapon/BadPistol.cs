using UnityEngine;

public class BadPistol : PlayerWeapon
{
    public BadPistol(GameObject gameObject, Character character, PlayerWeaponModel model) : base(gameObject, character, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_1);
        ItemFactory.Instance.CreatePlayerBullet(PlayerBulletType.Bullet_5, firePoint.transform.position, rotOrigin.transform.rotation);
    }
}