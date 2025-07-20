using UnityEngine;

public class MiddleSceneGameLoop : MonoBehaviour
{
    private MiddleScene.Facade facade;

    void Awake()
    {
        facade = new MiddleScene.Facade();
    }

    void Update()
    {
        facade.GameUpdate();
        if (Input.GetKeyDown(KeyCode.U)) GameMediator.Instance.GetSystem<InputSystem>().isLimitedWeapon = false;
    }
}
