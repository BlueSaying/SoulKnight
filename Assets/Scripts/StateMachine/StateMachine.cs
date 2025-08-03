using System;
using System.Collections.Generic;

public abstract class StateMachine
{
    private Dictionary<Type, State> stateDic;
    protected State curState;

    public StateMachine()
    {
        stateDic = new Dictionary<Type, State>();
    }

    // NOTE:给定要切换的状态T
    public virtual void SwitchState<T>()
    {
        // NOTE:如果不存在状态T，那么向stateDic中添加状态T
        if (!stateDic.ContainsKey(typeof(T)))
        {
            // 填写this代表新实例化的IState隶属于此状态机
            stateDic.Add(typeof(T), Activator.CreateInstance(typeof(T), this) as State);
        }

        curState?.OnExit();

        curState = stateDic[typeof(T)];
    }

    public void GameUpdate()
    {
        curState?.GameUpdate();
        OnUpdate();
    }

    protected virtual void OnUpdate() { }
}