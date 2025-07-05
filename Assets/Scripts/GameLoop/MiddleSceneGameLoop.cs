using UnityEngine;
using MiddleScene;

public class MiddleSceneGameLoop:MonoBehaviour
{
    private Facade facade;
    void Start()
    {
        facade = new Facade();
    }
    void Update()
    {
        facade.GameUpdate();
    }
}
