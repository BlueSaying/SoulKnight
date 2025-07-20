using UnityEngine;

public enum PlayerBulletType
{
    Bullet_5,
    Bullet_34,
}

public enum EffectType
{
    EffectBoom,
}

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory() { }

    public PlayerBullet CreatePlayerBullet(PlayerBulletType playerBulletType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = Object.Instantiate(ResourcesLoader.Instance.GetBullet(playerBulletType.ToString()), position, quaternion);
        PlayerBullet bullet = null;

        switch (playerBulletType)
        {
            case PlayerBulletType.Bullet_5:
                bullet = new Bullet_5(obj);
                break;
            case PlayerBulletType.Bullet_34:
                bullet = new Bullet_34(obj);
                break;
        }

        return bullet;
    }

    public BaseEffect CreateEffect(EffectType effectType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = Object.Instantiate(ResourcesLoader.Instance.GetEffect(effectType.ToString()), position, quaternion);
        BaseEffect effect = null;

        switch (effectType)
        {
            case EffectType.EffectBoom:
                effect = new EffectBoom(obj);
                break;
        }

        return effect;
    }

    public DamageNum CreateDamageNum(string canvasName, Transform parent, int damage, Color color)
    {
        GameObject obj = Object.Instantiate(ResourcesLoader.Instance.GetPanel(SceneName.BattleScene.ToString(), canvasName), parent);
        DamageNum damageNum = new DamageNum(obj, damage, color);

        return damageNum;
    }
}