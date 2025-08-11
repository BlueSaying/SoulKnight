using UnityEngine;

public abstract class PlayerState : State
{
    public new PlayerFSM fsm { get => base.fsm as PlayerFSM; set => base.fsm = value; }
    protected Player player;
    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;

    public PlayerState(PlayerFSM fsm) : base(fsm) { }

    protected override void OnInit()
    {
        base.OnInit();
        player = fsm.player;
        gameObject = player.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = UnityTools.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
    }
}