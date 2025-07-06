using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class KnightIdleState : IPlayerState
{
    private Vector2 _moveDir;
    public KnightIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
    protected override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("isIdle", true);

        rb.velocity = Vector2.zero;
    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isIdle", false);
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        _moveDir.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (_moveDir.magnitude > 0)
        {
            stateMachine.SetState<KnightWalkState>();
            return;
        }
        
    }
}