using UnityEngine;

public abstract class Pet : Character
{
    public new PetModel model { get => base.model as PetModel; set => base.model = value; }

    protected PetFSM stateMachine;
    public Player owner { get; protected set; }

    public Pet(GameObject obj, PetModel model, Player owner) : base(obj, model)
    {
        this.model = model;
        this.owner = owner;
    }

    public float DistanceToOwner()
    {
        return Vector2.Distance(transform.position, owner.transform.position);
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        stateMachine?.GameUpdate();
    }
}