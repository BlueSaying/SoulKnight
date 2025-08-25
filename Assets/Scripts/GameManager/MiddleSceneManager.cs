using UnityEngine;

namespace MiddleScene
{
    public class MiddleSceneManager : MonoBehaviour
    {
        private Facade facade;

        void Awake()
        {
            // 打开场景最初UI界面
            UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.RoomPanel.ToString());
            UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.GemPanel.ToString());

            // 播放BGM
            AudioManager.Instance.PlayBGM(AudioType.Bgm, AudioName.bgm_room);

            // 实例化相应的角色
            PlayerFactory.Instance.InstantiatePlayer(PlayerType.Knight, new Vector2(9, 7), Quaternion.identity);
            PlayerFactory.Instance.InstantiatePlayer(PlayerType.Rogue, new Vector2(6, -2), Quaternion.identity);

            // 实例化宝箱
            // HACK
            DecorationFactory.InstantiateChest(new Vector2(10.5f, -3.5f), Quaternion.identity);

            facade = new Facade();
        }

        private void OnEnable()
        {
            facade.TurnOn();
        }

        private void FixedUpdate()
        {
            facade.FixedUpdate();
        }

        void Update()
        {
            facade.Update();

            if (Input.GetKeyDown(KeyCode.V)) TestManager.Instance.isUnlockWeapon = !TestManager.Instance.isUnlockWeapon;
        }

        private void OnDisable()
        {
            facade.TurnOff();
        }
    }
}