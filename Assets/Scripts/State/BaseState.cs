using UnityEngine;

public abstract class BaseState
{
    public BaseStateMachine stateMachine { get; protected set; }

    private bool isInit;
    private bool isEnter;

    public BaseState(BaseStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected virtual void OnInit() { }

    protected virtual void OnEnter() { }

    public virtual void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        OnUpdate();
    }

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public virtual void OnExit()
    {
        isEnter = false;
    }
}