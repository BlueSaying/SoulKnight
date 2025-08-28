
using System;

public static class BuffFactory
{
    public static Buff CreateBuff(BuffType buffType, float duration, Character owner)
    {
        return Activator.CreateInstance(Type.GetType(buffType.ToString()),
            new object[] { duration, owner }) as Buff;
    }
}