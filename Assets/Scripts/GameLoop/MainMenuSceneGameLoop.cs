using UnityEngine;

public class MainMenuSceneGameLoop : MonoBehaviour
{
    private MainMenuScene.Facade facade;

    void Awake()
    {
        facade = new MainMenuScene.Facade();
    }

    void Update()
    {
        facade.GameUpdate();
    }
}
