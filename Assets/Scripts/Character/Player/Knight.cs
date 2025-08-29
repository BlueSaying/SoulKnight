using UnityEngine;

public class Knight : Player
{
    public Knight(GameObject obj, PlayerModel playerModel) : base(obj, playerModel)
    {
        skill = new KnightSkill_1(this);
    }



    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new KnightFSM(this);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        skill.OnFixedUpdate();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        skill.OnUpdate();
    }
}