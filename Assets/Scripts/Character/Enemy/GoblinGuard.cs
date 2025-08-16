using UnityEngine;

public class GoblinGuard : Enemy
{
    public GoblinGuard(GameObject obj, EnemyModel model) : base(obj, model) { }
    
    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        stateMachine = new GoblinGuardFSM(this);
    }

    public override void TakeDamage(int damage, Color damageColor)
    {
        base.TakeDamage(damage, damageColor);

    }
}