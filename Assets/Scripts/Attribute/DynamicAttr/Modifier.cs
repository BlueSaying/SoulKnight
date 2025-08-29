public abstract class Modifier
{
    public float value;

    public Modifier(float value)
    {
        this.value = value;
    }

    public abstract float Apply(float baseValue);
}

public class FlatModifier : Modifier
{
    public FlatModifier(float value = 0f) : base(value) { }

    public override float Apply(float baseValue)
    {
        return baseValue + value;
    }
}

public class PercentModifier : Modifier
{
    public PercentModifier(float value = 0f) : base(value) { }

    public override float Apply(float baseValue)
    {
        return baseValue * (1 + value);
    }
}