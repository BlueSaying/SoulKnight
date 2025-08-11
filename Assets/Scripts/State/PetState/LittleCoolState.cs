using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LittleCoolState : PetState
{
    public LittleCoolState(FSM fsm) : base(fsm) { }
}

public class LittleCoolIdleState : LittleCoolState
{
    public LittleCoolIdleState(FSM fsm) : base(fsm) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        rb.velocity = Vector2.zero;
        animator.SetBool("isIdle", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("isIdle", false);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (pet.DistanceToOwner() > 5f)
        {
            fsm.SwitchState<LittleCoolFollowState>();
        }
    }
}

public class LittleCoolFollowState : LittleCoolState
{
    public LittleCoolFollowState(FSM fsm) : base(fsm) { }

    private const float minDistance = 1f;
    private int curPathIndex;

    private List<Vector2> path;

    protected override void OnEnter()
    {
        base.OnEnter();

        CoroutinePool.Instance.StartCoroutine(this, SeekerLoop());
    }

    public override void OnExit()
    {
        base.OnExit();
        CoroutinePool.Instance.StopAllCoroutine(this);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        MoveToTarget();

        if (pet.DistanceToOwner() < 2f)
        {
            fsm.SwitchState<LittleCoolIdleState>();
        }
    }

    private void MoveToTarget()
    {
        if (path == null || curPathIndex >= path.Count) return;

        Vector2 dir = (path[curPathIndex] - (Vector2)transform.position).normalized;
        if (dir.x > 0)
        {
            pet.ChangeLeft(false, false);
        }
        if (dir.x < 0)
        {
            pet.ChangeLeft(true, false);
        }

        float speed = 5f;//pet.staticAttr.speed;
        rb.velocity = dir * speed;

        if (Vector2.Distance(transform.position, path[curPathIndex]) < minDistance)
        {
            curPathIndex++;
        }
    }

    private IEnumerator SeekerLoop()
    {
        while (true)
        {
            path = pathFinder.FindPath(transform.position, pet.owner.transform.position);
            curPathIndex = 0;

            yield return new WaitForSeconds(0.5f);
        }
    }
}