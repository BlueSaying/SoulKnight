using UnityEngine;

public class EnemyState : State
{
    public new EnemyFSM fsm { get => base.fsm as EnemyFSM; set => base.fsm = value; }

    protected Player targetPlayer;
    protected Enemy enemy;
    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;

    public EnemyState(FSM fsm) : base(fsm) { }
    protected override void OnInit()
    {
        base.OnInit();
        enemy = fsm.enemy;
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