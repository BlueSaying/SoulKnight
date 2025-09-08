using System;
using UnityEngine.Events;

/// <summary>
/// 动态属性类
/// </summary>
/// <typeparam name="T">int,float</typeparam>
public class DynamicAttr<T> where T : struct
{
    // a mark of wheather the value has updated
    private bool hasUpdated;

    // a mark of wheather the value is Interger
    private bool isInterger;

    private UnityAction actions;

    private float baseValue;

    private FlatModifier flatModifier;
    private PercentModifier percentModifier;

    private T value;
    public T Value
    {
        get
        {
            if (hasUpdated) return value;

            // 计算数值
            float output = baseValue;
            output = flatModifier.Apply(output);
            output = percentModifier.Apply(output);

            hasUpdated = true;

            if (isInterger) return value = (T)(object)(int)output;
            else return value = (T)(object)output;
        }
    }

    public DynamicAttr(float baseValue = 0f)
    {
        this.baseValue = baseValue;

        flatModifier = new FlatModifier();
        percentModifier = new PercentModifier();

        isInterger = typeof(T) == typeof(int);
    }

    public void AddFlatModifier(float value)
    {
        if (flatModifier == null)
        {
            flatModifier = new FlatModifier(value);
        }
        else
        {
            flatModifier.value += value;
        }

        hasUpdated = false;
        actions?.Invoke();
    }

    public void AddPercentModifier(float value)
    {
        if (percentModifier == null)
        {
            percentModifier = new PercentModifier(value);
        }
        else
        {
            percentModifier.value += value;
        }

        hasUpdated = false;
        actions?.Invoke();
    }

    // 添加当属性改变时的回调函数
    public void AddOnValueChangedCallBack(UnityAction action)
    {
        actions += action;
    }

    public void RemoveOnValueChangedCallBack(UnityAction action)
    {
        actions -= action;
    }
}