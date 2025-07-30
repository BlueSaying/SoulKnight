using System;
using System.Collections.Generic;

public abstract class AbstractFacade
{
    // 场景需要的Systems
    protected Dictionary<Type, BaseSystem> systems;

    private bool isInit;
    private bool isEnter;
    private bool isEnable;

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (isEnable)
        {
            OnUpdate();
        }
    }

    protected virtual void OnInit()
    {
        systems = new Dictionary<Type, BaseSystem>();
    }

    protected virtual void OnEnter() { }

    protected virtual void OnExit()
    {
        foreach (var system in systems.Values)
        {
            system.TurnOff();
        }
    }

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }

        foreach (var system in systems.Values)
        {
            system.GameUpdate();
        }
    }

    public void TurnOn()
    {
        isEnable = true;
    }

    public void TurnOff()
    {
        if (isEnable)
        {
            isEnable = false;
            isEnter = false;
            OnExit();
        }
    }
}
