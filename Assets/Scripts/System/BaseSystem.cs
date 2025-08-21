
using UnityEngine;

public abstract class BaseSystem
{
    private bool isInit;
    private bool isEnter;
    private bool isEnable;

    protected virtual void OnInit() { }

    protected virtual void OnEnter() { }

    protected virtual void OnExit() { }

    public void FixedUpdate()
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
}