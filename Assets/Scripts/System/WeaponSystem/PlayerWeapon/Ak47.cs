using UnityEngine;

public class Ak47 : PlayerWeapon
{
    public Ak47(GameObject gameObject, Character character, PlayerWeaponModel model) : base(gameObject, character, model) { }

    protected override void OnFire()
    {
        base.OnFire();

        SystemRepository.Instance.GetSystem<AudioSystem>().PlayAudio(AudioType.gun, AudioName.fx_gun_1);
        Bullet_34 bullet = ItemFactory.Instance.CreatePlayerBullet(PlayerBulletType.Bullet_34, firePoint.transform.position, rotOrigin.transform.rotation) as Bullet_34;
        bullet.ManagedToController();
    }
}