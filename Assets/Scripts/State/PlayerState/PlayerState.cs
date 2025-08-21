using UnityEngine;

public abstract class PlayerState : State
{
    public new PlayerFSM fsm { get => base.fsm as PlayerFSM; set => base.fsm = value; }
    protected Player player;
    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;

    protected Vector2 moveDir = Vector2.zero;

    public PlayerState(PlayerFSM fsm) : base(fsm) { }

    protected override void OnInit()
    {
        base.OnInit();
        player = fsm.player;
        gameObject = player.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = UnityTools.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        MoveManager.Move(rb, moveDir.normalized * player.speed);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        moveDir = (SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput());
    }
}