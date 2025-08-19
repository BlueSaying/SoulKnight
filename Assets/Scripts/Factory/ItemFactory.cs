using System;
using UnityEngine;

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory() { }

    public Bullet CreateBullet(BulletType bulletType, Vector3 position, Quaternion quaternion, Character owner, int damage)
    {
        ItemPool itemPool = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool;
        Bullet bullet = null;

        switch (bulletType)
        {
            case BulletType.Bullet_5:
                bullet = itemPool.GetItem<Bullet_5>() as Bullet;
                if (bullet != null)
                {
                    bullet.Reset(position, quaternion);
                }
                else
                {
                    bullet = new Bullet_5(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadBullet(bulletType.ToString()), position, quaternion), owner, damage);
                }
                break;
            case BulletType.Bullet_34:
                bullet = itemPool.GetItem<Bullet_34>() as Bullet;
                if (bullet != null)
                {
                    bullet.Reset(position, quaternion);
                }
                else
                {
                    bullet = new Bullet_34(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadBullet(bulletType.ToString()), position, quaternion), owner, damage);
                }
                break;
            case BulletType.BulletBasketball:
                bullet = itemPool.GetItem<BulletBasketball>() as Bullet;
                if (bullet != null)
                {
                    bullet.Reset(position, quaternion);
                }
                else
                {
                    bullet = new BulletBasketball(UnityEngine.Object.Instantiate(ResourcesLoader.Instance.LoadBullet(bulletType.ToString()), position, quaternion), owner, damage);
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

    public DamageNum CreateDamageNum(string canvasName, Vector2 position, int damage, Color color)
    {
        ItemPool itemPool = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool;
        DamageNum damageNum = null;
        damageNum = itemPool.GetItem<DamageNum>() as DamageNum;
        if (damageNum != null)
        {
            damageNum.Reset(position, damage, color);
        }
        else
        {
            GameObject prefab = ResourcesLoader.Instance.LoadPanel("Generic", canvasName);
            GameObject obj = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
            damageNum = new DamageNum(obj, damage, color);
        }

        return damageNum;
    }
}