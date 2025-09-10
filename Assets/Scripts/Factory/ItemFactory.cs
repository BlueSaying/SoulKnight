using System;
using UnityEngine;

public class ItemFactory : Singleton<ItemFactory>
{
    private ItemFactory() { }

    public Bullet CreateBullet(BulletType bulletType, Vector3 position, Quaternion quaternion,
        Character owner, int damage, bool isCritical, float bulletSpeed, BuffType buffType = BuffType.None)
    {
        Type type = Type.GetType(bulletType.ToString());
        Bullet bullet = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool.GetItem(type) as Bullet;

        if (bullet != null)
        {
            bullet.Reset(position, quaternion, damage, isCritical, buffType);
        }
        else
        {
            GameObject bulletPrefab = ResourcesLoader.Instance.LoadBullet(bulletType.ToString());
            GameObject newBullet = UnityEngine.Object.Instantiate(bulletPrefab, position, quaternion);
            bullet = Activator.CreateInstance(type, new object[] { newBullet, owner, damage, isCritical, bulletSpeed, buffType }) as Bullet;
        }

        return bullet;
    }

    public Effect CreateEffect(EffectType effectType, Vector3 position, Quaternion quaternion)// TODO :Add color
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

    public Dropped CreateDropped(DroppedType droppedType, Vector3 position, Quaternion quaternion)
    {
        Type type = Type.GetType(droppedType.ToString());
        Dropped dropped = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool.GetItem(type) as Dropped;

        // 给position一个随机位置波动
        position += new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));

        if (dropped != null)
        {
            dropped.Reset(position, quaternion);
        }
        else
        {
            GameObject droppedPrefab = ResourcesLoader.Instance.LoadDropped(droppedType.ToString());
            GameObject newDropped = UnityEngine.Object.Instantiate(droppedPrefab, position, quaternion);
            dropped = Activator.CreateInstance(type, new object[] { newDropped }) as Dropped;
        }

        return dropped;
    }

    public DamageNum CreateDamageNum(string canvasName, Vector2 position, int damage, Color color, int fontSize)
    {
        ItemPool itemPool = SystemRepository.Instance.GetSystem<ItemSystem>().itemPool;
        DamageNum damageNum = null;
        damageNum = itemPool.GetItem(typeof(DamageNum)) as DamageNum;
        if (damageNum != null)
        {
            damageNum.Reset(position, damage, color, fontSize);
        }
        else
        {
            GameObject prefab = ResourcesLoader.Instance.LoadPanel(SceneName.Generic.ToString(), canvasName);
            GameObject obj = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
            damageNum = new DamageNum(obj, damage, color, fontSize);
        }

        return damageNum;
    }

    // 在可互动物品上创建一个箭头
    public ItemArrow CreateItemArrow(string canvasName, string info, QualityType qualityType, Transform parent)
    {
        GameObject prefab = ResourcesLoader.Instance.LoadPanel(SceneName.Generic.ToString(), canvasName);
        GameObject obj = UnityEngine.Object.Instantiate(prefab, parent);

        ItemArrow itemArrow = new ItemArrow(obj.transform, info, qualityType);

        return itemArrow;
    }
}