using UnityEngine;

public class GoblinGuard : Enemy
{
    public GoblinGuard(GameObject obj, EnemyModel model) : base(obj, model) { }
    
    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new GoblinGuardFSM(this);
    }
}