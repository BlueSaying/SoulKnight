
using UnityEngine;

public abstract class BaseSystem
{
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

    protected virtual void OnInit() { }

    protected virtual void OnEnter() { }

    protected virtual void OnExit() { }

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
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