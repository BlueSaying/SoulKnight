
using System.Collections.Generic;
using UnityEngine;


public class ItemSystem : BaseSystem
{
    private List<Item> items;

    protected override void OnInit()
    {
        base.OnInit();
        items = new List<Item>();
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].hasRemoved)
            {
                // TODO:实现删除游戏物体
                items.RemoveAt(i);
            }
            else
            {
                items[i].GameUpdate();
            }
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }
}