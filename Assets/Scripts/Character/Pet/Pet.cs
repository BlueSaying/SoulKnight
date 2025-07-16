using UnityEngine;

public class Pet : Character
{
    public new PetStaticAttr staticAttr { get => base.staticAttr as PetStaticAttr; set => base.staticAttr = value; }
    public new PetDynamicAttr dynamicAttr { get => base.dynamicAttr as PetDynamicAttr; set => base.dynamicAttr = value; }

    protected PetStateMachine stateMachine;
    public Player owner { get; protected set; }

    public Pet(GameObject obj, PetStaticAttr staticAttr, Player owner) : base(obj, staticAttr)
    {
        //staticAttr = DynamicAttrFactory.Instance.GetPetStaticAttr(PetType.LittleCool);
        this.owner = owner;
    }

    public float DistanceToOwner()
    {
        return Vector2.Distance(transform.position, owner.transform.position);
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        stateMachine.GameUpdate();
    }
}