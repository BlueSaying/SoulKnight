using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : BaseSystem
{
    private List<Item> activeItems;
    public ItemPool itemPool { get; private set; }

    protected override void OnInit()
    {
        base.OnInit();
        activeItems = new List<Item>();
        itemPool = new ItemPool();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        for (int i = activeItems.Count - 1; i >= 0; i--)
        {
            var item = activeItems[i];
            if (item.isRemoved)
            {
                activeItems.RemoveAt(i);
                itemPool.ReleaseItem(item);
            }
            else
            {
                item.GameUpdate();
            }
        }

        int count = 0;
        foreach (var item in itemPool.pool.Values)
        {
            count += item.Count;
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
        foreach (var item in activeItems)
        {
            GameObject.Destroy(item.gameObject);
        }

        activeItems.Clear();
        itemPool.Clear();
    }

    public void AddActiveItem(Item item)
    {
        activeItems.Add(item);
    }
}

public class ItemPool
{
    private const int poolSize = 100;
    private int curPoolSize = 0;

    public Dictionary<Type, Queue<Item>> pool { get; private set; }

    public ItemPool()
    {
        pool = new Dictionary<Type, Queue<Item>>();
    }

    // clear this ItemPool
    public void Clear()
    {
        pool.Clear();
        curPoolSize = 0;
    }

    // get item from itemPool
    public Item GetItem<T>() where T : Item
    {
        Type type = typeof(T);
        if (!pool.ContainsKey(type)) return null;

        Queue<Item> queue = pool[type];

        if (queue == null || queue.Count == 0)
        {
            return null;
        }
        else
        {
            T result = queue.Dequeue() as T;
            curPoolSize--;
            result.gameObject.SetActive(true);

            return result as T;
        }
    }

    // return item back to itemPool
    public void ReleaseItem(Item item)
    {
        if (curPoolSize >= poolSize)
        {
            GameObject.Destroy(item.gameObject);
            return;
        }

        Type itemType = item.GetType();

        if (!pool.ContainsKey(itemType))
        {
            pool.Add(itemType, new Queue<Item>());
        }

        pool[itemType].Enqueue(item);
        item.gameObject.SetActive(false);
        curPoolSize++;
    }
}