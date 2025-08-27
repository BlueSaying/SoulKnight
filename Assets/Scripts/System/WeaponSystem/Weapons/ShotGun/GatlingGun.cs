using UnityEngine;

public class GatlingGun : ShotGun
{
    public GatlingGun(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnFire()
    {
        base.OnFire();

        // 连续发射4发子弹
        const int Times = 4;
        for (int i = 0; i < Times; i++)
        {
            AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

            // 计算散布
            Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
            ItemFactory.Instance.CreateBullet(BulletType.Bullet_130, shootPoint.transform.position, quaternion, owner, Damage, BulletSpeed);
        }
    }
}