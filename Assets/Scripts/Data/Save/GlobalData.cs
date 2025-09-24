using System;
using UnityEngine;

[Serializable]
public class GlobalData
{
    [SerializeField]
    private int gemCount;
    public int GemCount
    {
        get => gemCount;
        set
        {
            gemCount = value;
            SaveManager.Instance.SaveData();
        }
    }

    // 默认构造函数，用于创建新存档时的默认值
    public GlobalData()
    {
        gemCount = 0;
    }

    public GlobalData(int gemCount)
    {
        this.gemCount = gemCount;
    }
}