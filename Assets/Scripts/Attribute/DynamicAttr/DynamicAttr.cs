using System;
using System.Collections.Generic;

public class DynamicAttr
{
    // a mark of wheather the value has updated
    private bool hasUpdated;

    private float baseValue;

    private Dictionary<Type, Modifier> modifiers = new Dictionary<Type, Modifier>();

    private float value;
    public float Value
    {
        get
        {
            if (hasUpdated) return value;

            float output = baseValue;

            foreach (var modifier in modifiers.Values)
            {
                output = modifier.Apply(output);
            }

            hasUpdated = true;
            return value = output;
        }
    }

    public void AddModifier(Modifier modifier)
    {
        Type modifierType = modifier.GetType();

        if (modifiers.ContainsKey(modifierType))
        {
            modifiers[modifierType].value = modifiers[modifierType].Apply(modifier.value);
        }
        else
        {
            modifiers.Add(modifierType, modifier);
        }

        hasUpdated = false;
    }

    public DynamicAttr(float baseValue = 0f)
    {
        this.baseValue = baseValue;
    }
}