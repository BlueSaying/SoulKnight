public class PetStateMachine : BaseStateMachine
{
    public BasePet pet { get; protected set; }
    public PetStateMachine(BasePet pet) : base()
    {
        this.pet = pet;
    }
}