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

            if (Input.GetKeyDown(KeyCode.T))
            {
                if (UIMediator.Instance.IsPanelOpened(Generic.PanelName.TestPanel.ToString()))
                {
                    UIMediator.Instance.ClosePanel(Generic.PanelName.TestPanel.ToString());
                }
                else
                {
                    UIMediator.Instance.OpenPanel(SceneName.Generic, Generic.PanelName.TestPanel.ToString());
                }
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                // 随机选择一种金币实例化
                DroppedType[] droppedTypes = new DroppedType[] { DroppedType.CopperCoin, DroppedType.SliverCoin, DroppedType.GoldCoin };
                DroppedType droppedTypeByRandom = droppedTypes[Random.Range(0, droppedTypes.Length)];

                ItemFactory.Instance.CreateDropped(droppedTypeByRandom, new Vector2(-5, 5), Quaternion.identity);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemFactory.Instance.CreateDropped(DroppedType.EnergyBall, new Vector2(-5, 5), Quaternion.identity);
            }
        }

        private void OnDisable()
        {
            facade.TurnOff();
        }
    }
}