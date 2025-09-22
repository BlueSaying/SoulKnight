using System;

public static class BuffFactory
{
    public static Buff CreateBuff(BuffType buffType, Character owner)
    {
        return Activator.CreateInstance(Type.GetType(buffType.ToString()),
            new object[] { owner }) as Buff;
    }
}