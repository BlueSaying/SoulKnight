using UnityEngine;

public class BasePet : ICharacter
{
    public new PetStaticAttr staticAttr { get => base.staticAttr as PetStaticAttr; set => base.staticAttr = value; }
    public new PetDynamicAttr dynamicAttr { get => base.dynamicAttr as PetDynamicAttr; set => base.dynamicAttr = value; }

    protected PetStateMachine stateMachine;
    public IPlayer owner { get; protected set; }

    public BasePet(GameObject obj, IPlayer owner) : base(obj)
    {
        staticAttr = AttributeFactory.Instance.GetPetStaticAttr(PetType.LittleCool);
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