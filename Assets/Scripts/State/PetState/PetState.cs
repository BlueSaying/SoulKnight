using Pathfinding;
using UnityEngine;

public class PetState : State
{
    public new PetStateMachine stateMachine { get => base.stateMachine as PetStateMachine; set => base.stateMachine = value; }
    protected Pet pet;

    protected GameObject gameObject;
    protected Transform transform => gameObject.transform;
    protected Rigidbody2D rb;
    protected Animator animator;

    protected Seeker seeker;
    protected Path path;

    public PetState(StateMachine stateMachine) : base(stateMachine) { }

    protected override void OnInit()
    {
        base.OnInit();
        pet = stateMachine.pet;
        gameObject = pet.gameObject;
        rb = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        seeker = transform.GetComponent<Seeker>();
    }
}