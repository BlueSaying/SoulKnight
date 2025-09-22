using System.Collections.Generic;

public static class StringExtensions
{
    private static readonly Dictionary<string, string> ToChineseDic = new Dictionary<string, string>()
    {
        // 武器类
        // 手枪
        {"BadPistol", "破旧的手枪"},
        {"DesertEagle", "沙漠之鹰"},
        {"P250Pistol", "P250手枪"},

        // 步枪
        {"AK47","AK47" },
        {"AssaultRifle","突击步枪" },
        {"GasBlaster","毒气机枪" },

        // 近战
        {"GoblinSpear","哥布林长枪" },

        // 弓
        {"StrongBow","强弓" },
        {"CompositeBow","复合弓" },

        // 散弹枪
        {"GatlingGun","加特林" },
        {"SidewinderRed","红色响尾蛇" },
        {"SidewinderGreen","绿色响尾蛇" },

        // 法杖
        {"StaffOfFlame","火之杖" },

        // 杂项
        {"Basketball","篮球" },

        //火箭筒
        {"Bazooka","火箭筒" },



        // 角色
        {"Knight","骑士" },
        {"Rogue","游侠" },



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