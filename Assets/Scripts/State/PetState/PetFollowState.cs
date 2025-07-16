using System.Collections;
using UnityEngine;

public class PetFollowState : PetState
{
    private const float minDistance = 1f;

    private int curPathIndex;

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
        if (path == null || curPathIndex >= path.vectorPath.Count) return;

        Vector2 dir = (path.vectorPath[curPathIndex] - transform.position).normalized;

        if (dir.x > 0)
        {
            pet.isLeft = false;
        }
        if (dir.x < 0)
        {
            pet.isLeft = true;
        }

        float speed = 5f;//pet.staticAttr.speed;
        transform.position += (Vector3)dir * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, path.vectorPath[curPathIndex]) < minDistance)
        {
            curPathIndex++;
        }
    }

    private IEnumerator SeekerLoop()
    {
        while (true)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(transform.position, pet.owner.transform.position, (p) =>
                {
                    path = p;
                    curPathIndex = 1;
                });
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}