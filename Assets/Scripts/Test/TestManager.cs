
public class TestManager : Singleton<TestManager>
{
    // 是否解除武器限制
    public bool isUnlockWeapon;

    private TestManager()
    {
        isUnlockWeapon = false;
    }

    //if (Input.GetKeyDown(KeyCode.U)) GameMediator.Instance.GetSystem<InputSystem>().isLimitedWeapon = false;
}