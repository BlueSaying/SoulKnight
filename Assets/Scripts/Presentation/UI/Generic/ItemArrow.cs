
// 物品指示箭头
using UnityEngine;
using UnityEngine.UI;

public class ItemArrow
{
    public Transform transform;

    public ItemArrow(Transform transform, string info)
    {
        this.transform = transform;
        transform.Find("Info").GetComponent<Text>().text = info;
    }
}