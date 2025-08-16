using UnityEngine;

public class Ak47 : Weapon
{
    public Ak47(GameObject gameObject, Character character, WeaponModel model) : base(gameObject, character, model) { }

    protected override void OnFire()
    {
        base.OnFire();
        AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_1);
        ItemFactory.Instance.CreatePlayerBullet(BulletType.Bullet_34, firePoint.transform.position, rotOrigin.transform.rotation);
    }
}