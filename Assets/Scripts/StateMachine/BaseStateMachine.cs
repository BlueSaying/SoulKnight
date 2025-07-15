using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine
{
    private Dictionary<Type, BaseState> stateDic;
    protected BaseState curState;

    public BaseStateMachine()
    {
        stateDic = new Dictionary<Type, BaseState>();
    }

    // NOTE:给定要切换的状态T
    public void SwitchState<T>()
    {
        // NOTE:如果不存在状态T，那么向stateDic中添加状态T
        if (!stateDic.ContainsKey(typeof(T)))
        {
            // 填写this代表新实例化的IState隶属于此状态机
            stateDic.Add(typeof(T), Activator.CreateInstance(typeof(T), this) as BaseState);
        }

        curState?.OnExit();

        curState = stateDic[typeof(T)];
    }

    public void StopCurrentState()
    {
        curState?.OnExit();
    }

    public void GameUpdate()
    {
        curState?.GameUpdate();
        OnUpdate();
    }

    protected virtual void OnUpdate() { }
}