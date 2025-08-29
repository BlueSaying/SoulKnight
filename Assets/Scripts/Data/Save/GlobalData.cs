using System;

[Serializable]
public class GlobalData
{
    public int GemCount;

    // 默认构造函数，用于创建新存档时的默认值
    public GlobalData()
    {
        GemCount = 0;
    }

    public GlobalData(int gemCount)
    {
        GemCount = gemCount;
    }
}