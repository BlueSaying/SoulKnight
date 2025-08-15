public class GoblinGuardFSM : EnemyFSM
{
    public GoblinGuardFSM(Enemy enemy) : base(enemy)
    {
        SwitchState<GoblinGuardIdleState>();
    }
}