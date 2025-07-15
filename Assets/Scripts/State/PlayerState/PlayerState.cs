using UnityEngine;

public abstract class PlayerState : BaseState
{
    public new PlayerStateMachine stateMachine { get => base.stateMachine as PlayerStateMachine; set => base.stateMachine = value; }
    protected IPlayer player;
    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;
    public PlayerState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    protected override void OnInit()
    {
        base.OnInit();
        player = stateMachine.player;
        gameObject = player.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = UnityTools.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
    }
    protected override void OnEnter()
    {
        base.OnEnter();

    }
}