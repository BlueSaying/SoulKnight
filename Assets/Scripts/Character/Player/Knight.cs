using UnityEngine;

public class Knight : Player
{
    public Knight(GameObject obj, PlayerModel playerModel, Skill skill) : base(obj, playerModel, skill) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new KnightFSM(this);
        skill = new KnightSkill_1(this);
    }
}