using UnityEngine;

public enum PlayerBulletType
{
    Bullet_5,

}

public enum EffectType
{
    EffectBoom,
}

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory() { }

    public BasePlayerBullet GetPlayerBullet(PlayerBulletType playerBulletType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetBullet(playerBulletType.ToString()), position, quaternion);
        BasePlayerBullet bullet = null;

        switch (playerBulletType)
        {
            case PlayerBulletType.Bullet_5:
                bullet = new Bullet_5(obj);
                break;
        }

        return bullet;
    }

    public BaseEffect GetEffect(EffectType effectType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetEffect(effectType.ToString()), position, quaternion);

        BaseEffect effect = null;
    
        switch (effectType)
        {
            case EffectType.EffectBoom:
                effect = new EffectBoom(obj);
                break;
        }
    
        return effect;
    }
}