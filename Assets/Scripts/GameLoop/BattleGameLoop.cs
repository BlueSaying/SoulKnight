using UnityEngine;

public class BattleGameLoop : MonoBehaviour
{
    private BattleScene.Facade facade;

    void Awake()
    {
        facade = new BattleScene.Facade();
    }

    void Update()
    {
        facade.GameUpdate();
    }
}

