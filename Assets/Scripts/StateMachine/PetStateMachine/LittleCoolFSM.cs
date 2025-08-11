
public class LittleCoolFSM : PetFSM
{
    public LittleCoolFSM(Pet pet) : base(pet)
    {
        SwitchState<LittleCoolIdleState>();
    }
}