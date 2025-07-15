
public class LittleCoolStateMachine : PetStateMachine
{
    public LittleCoolStateMachine(BasePet pet) : base(pet)
    {
        SwitchState<PetIdleState>();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if(curState is PetIdleState)
        {
            if(pet.DistanceToOwner()>5f)
            {
                SwitchState<PetFollowState>();
            }
        }

        if(curState is PetFollowState)
        {
            if(pet.DistanceToOwner()<2f)
            {
                SwitchState<PetIdleState>();
            }
        }
    }
}