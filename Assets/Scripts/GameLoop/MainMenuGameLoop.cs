using MainMenuScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameLoop : MonoBehaviour
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
