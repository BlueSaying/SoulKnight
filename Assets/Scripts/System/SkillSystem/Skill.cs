public abstract class Skill
{
    private bool isInit;

    public Player owner { get; protected set; }

    public Skill(Player owner)
    {
        this.owner = owner;
    }

    public abstract void RealeaseSkill();

    protected virtual void OnInit() { }

    public virtual void OnUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
    }

    public virtual void OnFixedUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
    }
}