using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : BaseSystem
{
    private List<Item> items;
    public ItemPool itemPool { get; private set; }

    protected override void OnInit()
    {
        base.OnInit();
        items = new List<Item>();
        itemPool = new ItemPool();
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        foreach (var item in items)
        {
            if (!item.isRemoved)
            {
                item.OnFixedUpdate();
            }
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        foreach (var item in items)
        {
            if (!item.isRemoved)
            {
                item.OnUpdate();
            }
        }
    }

    protected override void OnExit()
    {
        base.OnExit();
        foreach (var item in items)
        {
            GameObject.Destroy(item.gameObject);
        }

        items.Clear();
        itemPool.Clear();
    }

    public void AddActiveItem(Item item)
    {
        items.Add(item);
    }
}

public class ItemPool
{
    private const int poolSize = 500;
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
    public Item GetItem(Type type)
    {
        if (!type.IsSubclassOf(typeof(Item)) || !pool.ContainsKey(type)) return null;

        Queue<Item> queue = pool[type];

        if (queue == null || queue.Count == 0)
        {
            return null;
        }
        else
        {
            Item result = queue.Dequeue();
            curPoolSize--;
            result.gameObject.SetActive(true);

            return result;
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

    public bool ContainsItem(Item item)
    {
        if (!pool.TryGetValue(item.GetType(), out Queue<Item> queue)) return false;
        return queue.Contains(item);
    }
}