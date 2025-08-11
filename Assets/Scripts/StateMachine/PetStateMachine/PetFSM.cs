public class PetFSM : FSM
{
    public Pet pet { get; protected set; }
    public PetFSM(Pet pet) : base()
    {
        this.pet = pet;
    }
}