
public abstract class AbstractFacade
{
    private bool isInit;

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        OnUpdate();
    }

    protected virtual void OnInit() { }

    protected virtual void OnUpdate()
    {
        
    }
}
