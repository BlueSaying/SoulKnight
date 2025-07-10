using System;
using System.Collections.Generic;

public abstract class IStateMachine
{
    private Dictionary<Type, IState> stateDic;
    private IState currentState;
    public IStateMachine()
    {
        stateDic = new Dictionary<Type, IState>();
    }

    // NOTE:给定要切换的状态T
    public void SwitchState<T>()
    {
        // NOTE:如果不存在状态T，那么向stateDic中添加状态T
        if (!stateDic.ContainsKey(typeof(T)))
        {
            // 填写this代表新实例化的IState隶属于此状态机
            stateDic.Add(typeof(T), Activator.CreateInstance(typeof(T), this) as IState);
        }

        currentState?.OnExit();

        currentState = stateDic[typeof(T)];
    }
    public void StopCurrentState()
    {
        currentState?.OnExit();
    }
    public void GameUpdate()
    {
        currentState?.GameUpdate();
    }
}