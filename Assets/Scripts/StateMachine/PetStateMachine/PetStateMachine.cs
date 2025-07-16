public class PetStateMachine : StateMachine
{
    public Pet pet { get; protected set; }
    public PetStateMachine(Pet pet) : base()
    {
        this.pet = pet;
    }
}