
public class EnemyFSM : FSM
{
    protected Player targetPlayer=> SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
    public Enemy enemy { get; protected set; }

    public EnemyFSM(Enemy enemy) : base()
    {
        this.enemy = enemy;
    }
}