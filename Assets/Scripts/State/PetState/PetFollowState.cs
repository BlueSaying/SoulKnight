using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollowState : PetState
{
    private const float minDistance = 1f;
    private int curPathIndex;

    private List<Vector2> path;

    public PetFollowState(StateMachine stateMachine) : base(stateMachine) { }

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
    }

    private void MoveToTarget()
    {
        if (path == null || curPathIndex >= path.Count) return;

        Vector2 dir = (path[curPathIndex] - (Vector2)transform.position).normalized;
        Debug.Log(((Vector2)transform.position).ToString() + path[curPathIndex].ToString());
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
        //transform.position +=  * Time.deltaTime;

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