using System;
using UnityEngine;

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory() { }

    public Bullet CreateBullet(BulletType bulletType, Vector3 position, Quaternion quaternion,
        Character owner, int damage, float bulletSpeed, BuffType buffType = BuffType.None)
    {
        Type type = Type.GetType(bulletType.ToString());
        Bullet bullet = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool.GetItem(type) as Bullet;

        if (bullet != null)
        {
            bullet.Reset(position, quaternion, damage);
        }
        else
        {
            GameObject bulletPrefab = ResourcesLoader.Instance.LoadBullet(bulletType.ToString());
            GameObject newBullet = UnityEngine.Object.Instantiate(bulletPrefab, position, quaternion);
            bullet = Activator.CreateInstance(type, new object[] { newBullet, owner, damage, bulletSpeed, buffType }) as Bullet;
        }

        return bullet;
    }

    public Effect CreateEffect(EffectType effectType, Vector3 position, Quaternion quaternion)
    {
        Type type = Type.GetType(effectType.ToString());
        Effect effect = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool.GetItem(type) as Effect;

        if (effect != null)
        {
            effect.Reset(position, quaternion);
        }
        else
        {
            GameObject effectPrefab = ResourcesLoader.Instance.LoadEffect(effectType.ToString());
            GameObject newEffect = UnityEngine.Object.Instantiate(effectPrefab, position, quaternion);
            effect = Activator.CreateInstance(type, new object[] { newEffect }) as Effect;
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
            GameObject prefab = ResourcesLoader.Instance.LoadPanel(SceneName.Generic.ToString(), canvasName);
            GameObject obj = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
            damageNum = new DamageNum(obj, damage, color);
        }

        return damageNum;
    }

    public ItemArrow CreateItemArrow(string canvasName, string info, QualityType qualityType, Transform parent)
    {
        GameObject prefab = ResourcesLoader.Instance.LoadPanel(SceneName.Generic.ToString(), canvasName);
        GameObject obj = UnityEngine.Object.Instantiate(prefab, parent);

        ItemArrow itemArrow = new ItemArrow(obj.transform, info, qualityType);

        return itemArrow;
    }
}