using UnityEngine;

public class BadPistol : IPlayerWeapon
{
    public BadPistol(GameObject gameObject, ICharacter character) : base(gameObject, character) { }

    protected override void OnFire()
    {
        base.OnFire();

        Quaternion quaternion = rotOrigin.transform.rotation;
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetBullet("Bullet_5"), firePoint.transform.position, quaternion);
        Bullet_5 bullet = new Bullet_5(obj);
        
        bullet.ManagedToController();
    }
}