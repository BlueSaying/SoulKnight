using UnityEngine;

public class MainMenuGameLoop : MonoBehaviour
{
    private MainMenuScene.Facade facade;

    void Start()
    {
        facade = new MainMenuScene.Facade();
    }

    void Update()
    {
        facade.GameUpdate();
    }
}
