using UnityEngine;

public class StaffOfFlame : Staff
{
    public StaffOfFlame(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnInit()
    {
        base.OnInit();
        animator.SetTrigger("PickUp");
    }

    protected override void OnFire()
    {
        base.OnFire();

        animator.SetTrigger("Attack");

        // 连续发射子弹
        for (int i = 0; i < bulletCount; i++)
        {
            AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_1);

            // 计算散布
            Quaternion baseQuaternion = Quaternion.Euler(0, 0, angle * (bulletCount - 1) / 2.0f - 1.0f * i * angle);
            Quaternion quaternion = baseQuaternion * rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-ScatterRate / 2.0f, ScatterRate / 2.0f));
            var damageInfo = CalcDamageInfo();
            int damage = damageInfo.damage;
            bool isCritical = damageInfo.isCritical;

            ItemFactory.Instance.CreateBullet(BulletType.Bullet_105, shootPoint.transform.position, quaternion,
                owner, damage, isCritical, BulletSpeed, isCritical ? BuffType : BuffType.None);
        }
    }
}