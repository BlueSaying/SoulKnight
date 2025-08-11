using UnityEngine;

public class PetState : State
{
    public new PetFSM fsm { get => base.fsm as PetFSM; set => base.fsm = value; }
    protected Pet pet;

    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;

    protected PathFinder pathFinder;

    public PetState(FSM fsm) : base(fsm) { }

    protected override void OnInit()
    {
        base.OnInit();
        pet = fsm.pet;
        gameObject = pet.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = transform.Find("Sprite").GetComponent<Animator>();

        pathFinder = new PathFinder();
    }
}