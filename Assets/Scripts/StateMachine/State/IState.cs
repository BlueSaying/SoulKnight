using UnityEngine;

public abstract class IState
{
    public IStateMachine stateMachine { get; protected set; }

    private bool isInit;
    private bool isEnter;

    public IState(IStateMachine stateMachine)
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