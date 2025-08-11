public abstract class State
{
    public FSM fsm { get; protected set; }

    private bool isInit;
    private bool isEnter;

    public State(FSM fsm)
    {
        this.fsm = fsm;
    }

    protected virtual void OnInit() { }

    protected virtual void OnEnter() { }

    public void GameUpdate()
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