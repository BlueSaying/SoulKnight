using System.Collections.Generic;

public static class StringExtensions
{
    private static readonly Dictionary<string, string> ToChineseDic = new Dictionary<string, string>()
    {
        // 武器类
        {"BadPistol", "破旧的手枪"},
        {"DesertEagle", "沙漠之鹰"},
        {"P250Pistol", "P250手枪"},

        {"AK47","AK47" },
        {"AssaultRifle","突击步枪" },
        {"GasBlaster","毒气机枪" },

        {"GoblinSpear","哥布林长枪" },

        {"StrongBow","强弓" },
        {"CompositeBow","复合弓" },

        {"GatlingGun","加特林" },

        {"Basketball","篮球" },

        // 杂项
        {"Chest","宝箱" },
    };

    public static string ToChinese(this string str)
    {
        foreach (var key in ToChineseDic.Keys)
        {
            str = str.Replace(key, ToChineseDic[key]);
        }

        return str;
    }
}