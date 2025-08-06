using UnityEngine;

namespace BattleScene
{
    public class BattleSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            facade = new Facade();
        }

        private void OnEnable()
        {
            facade.TurnOn();
        }

        void Update()
        {
            facade.GameUpdate();

            if (Input.GetKeyDown(KeyCode.U)) TestManager.Instance.isUnlockWeapon = !TestManager.Instance.isUnlockWeapon;
        }

        private void OnDisable()
        {
            facade.TurnOff();
        }
    }
}