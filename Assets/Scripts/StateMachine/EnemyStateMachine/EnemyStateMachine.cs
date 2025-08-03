
public class EnemyStateMachine : StateMachine
{
    protected Player targetPlayer;
    public Enemy enemy { get; protected set; }
    public EnemyStateMachine(Enemy enemy) : base()
    {
        this.enemy = enemy;
    }

    public override void SwitchState<T>()
    {
        base.SwitchState<T>();

        targetPlayer = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
    }
}