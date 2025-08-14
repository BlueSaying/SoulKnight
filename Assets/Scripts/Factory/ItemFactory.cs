using System;
using UnityEngine;
using UnityEngine.UIElements;

public enum PlayerBulletType
{
    Bullet_5,
    Bullet_34,
}

public enum EffectType
{
    /// <summary>
    /// 子弹碰撞
    /// </summary>
    BoomEffect,

    /// <summary>
    /// 敌人生成
    /// </summary>
    SummonEffect,

    /// <summary>
    /// 敌人出现
    /// </summary>
    AppearEffect,
}

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory() { }

    public PlayerBullet CreatePlayerBullet(PlayerBulletType playerBulletType, Vector3 position, Quaternion quaternion)
    {
        ItemPool itemPool = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool;
        PlayerBullet bullet = null;

        switch (playerBulletType)
        {
            case PlayerBulletType.Bullet_5:
                bullet = itemPool.GetItem<Bullet_5>() as PlayerBullet;
                if (bullet != null)
                {
                    bullet.Reset(position, quaternion);
                }
                else
                {
                    bullet = new Bullet_5(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadBullet(playerBulletType.ToString()), position, quaternion));
                }
                break;
            case PlayerBulletType.Bullet_34:
                bullet = itemPool.GetItem<Bullet_34>() as PlayerBullet;
                if (bullet != null)
                {
                    bullet.Reset(position, quaternion);
                }
                else
                {
                    bullet = new Bullet_34(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadBullet(playerBulletType.ToString()), position, quaternion));
                }
                break;
        }

        return bullet;
    }

    public Effect CreateEffect(EffectType effectType, Vector3 position, Quaternion quaternion)
    {
        ItemPool itemPool = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool;
        Effect effect = null;

        switch (effectType)
        {
            case EffectType.BoomEffect:
                effect = itemPool.GetItem<BoomEffect>() as Effect;
                if (effect != null)
                {
                    effect.Reset(position, quaternion);
                }
                else
                {
                    effect = new BoomEffect(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadEffect(effectType.ToString()), position, quaternion));
                }
                break;
            case EffectType.SummonEffect:
                effect = itemPool.GetItem<SummonEffect>() as Effect;
                if (effect != null)
                {
                    effect.Reset(position, quaternion);
                }
                else
                {
                    effect = new SummonEffect(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadEffect(effectType.ToString()), position, quaternion));
                }
                break;
            case EffectType.AppearEffect:
                effect = itemPool.GetItem<AppearEffect>() as Effect;
                if (effect != null)
                {
                    effect.Reset(position, quaternion);
                }
                else
                {
                    effect = new AppearEffect(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadEffect(effectType.ToString()), position, quaternion));
                }
                break;
        }

        return effect;
    }

    public DamageNum CreateDamageNum(string canvasName, Transform parent, int damage, Color color)
    {
        ItemPool itemPool = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool;
        DamageNum damageNum = null;
        damageNum = itemPool.GetItem<DamageNum>() as DamageNum;
        if (damageNum != null)
        {
            damageNum.Reset();
        }
        else
        {
            damageNum = new DamageNum(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadPanel("Generic", canvasName), parent), damage, color);
        }

        return damageNum;
    }
}