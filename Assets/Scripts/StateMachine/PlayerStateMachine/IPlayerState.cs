using UnityEngine;

public abstract class IPlayerState : IState
{
    public PlayerStateMachine playerStateMachine { get => base.stateMachine as PlayerStateMachine; set => base.stateMachine = value; }
    protected IPlayer player;
    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;
    public IPlayerState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    protected override void OnInit()
    {
        base.OnInit();
        player = playerStateMachine.player;
        gameObject = player.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = UnityTools.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
    }
    protected override void OnEnter()
    {
        base.OnEnter();

    }
}