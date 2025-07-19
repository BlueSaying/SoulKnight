using UnityEngine;

public class MiddleSceneGameLoop : MonoBehaviour
{
    private MiddleScene.Facade facade;

    void Start()
    {
        facade = new MiddleScene.Facade();
    }

    void Update()
    {
        facade.GameUpdate();

        if (Input.GetKeyDown(KeyCode.U)) GameMediator.Instance.GetController<InputController>().isLimitedWeapon = false;
    }
}
