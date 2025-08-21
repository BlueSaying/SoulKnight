using System;
using System.Collections.Generic;

public abstract class AbstractFacade
{
    // 场景需要的Systems
    protected Dictionary<Type, BaseSystem> systems;

    private bool isInit;
    private bool isEnter;
    private bool isEnable;

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

    public void FixedUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }        

        if(isEnable)
        {
            if (!isEnter)
            {
                isEnter = true;
                OnEnter();
            }

            foreach (var system in systems.Values)
            {
                system.FixedUpdate();
            }

            OnFixedUpdate();
        }
    }

    protected virtual void OnFixedUpdate() { }

    public void Update()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (isEnable)
        {
            if (!isEnter)
            {
                isEnter = true;
                OnEnter();
            }

            foreach (var system in systems.Values)
            {
                system.Update();
            }

            OnUpdate();
        }
    }

    protected virtual void OnUpdate() { }

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

    public void AddSystem<T>() where T : BaseSystem
    {
        systems.Add(typeof(T), SystemRepository.Instance.GetSystem<T>());
    }
}
