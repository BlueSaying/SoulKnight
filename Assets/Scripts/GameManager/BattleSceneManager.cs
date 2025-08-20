using UnityEngine;

namespace BattleScene
{
    public class BattleSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            // 打开场景最初UI界面
            UIMediator.Instance.OpenPanel(SceneName.BattleScene, PanelName.BattlePanel.ToString());
            WeaponFactory.Instance.InstantiateWeapon(WeaponType.AK47, new Vector2(5, 0), Quaternion.identity);
            // 播放BGM
            AudioManager.Instance.PlayBGM(AudioType.Bgm, AudioName.bgm_1Low);

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