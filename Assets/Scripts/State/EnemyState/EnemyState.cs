
using UnityEngine;

public class EnemyState : State
{
    public new EnemyStateMachine stateMachine { get => base.stateMachine as EnemyStateMachine; set => base.stateMachine = value; }

    protected Player targetPlayer;
    protected Enemy enemy;
    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;

    public EnemyState(StateMachine stateMachine) : base(stateMachine) { }
    protected override void OnInit()
    {
        base.OnInit();
        enemy = stateMachine.enemy;
        gameObject = enemy.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = UnityTools.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        targetPlayer = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
    }
}