
using System.Collections.Generic;
using UnityEngine;


public class ItemController : AbstractController
{
    private List<Item> bullets;

    protected override void OnInit()
    {
        base.OnInit();
        bullets = new List<Item>();
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();

        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i].hasRemoved)
            {
                // TODO:实现删除游戏物体
                bullets.RemoveAt(i);
            }
            else
            {
                bullets[i].GameUpdate();
            }
        }
    }

    public void AddItem(Item bullet)
    {
        bullets.Add(bullet);
    }
}