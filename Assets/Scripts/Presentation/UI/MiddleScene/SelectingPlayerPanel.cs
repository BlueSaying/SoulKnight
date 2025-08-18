using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class SelectingPlayerPanel : Panel
    {
        private Button UIbackButton;
        private Button UInextButton;


        protected override void Awake()
        {
            base.Awake();

            InitData();

            UIbackButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack");
            UInextButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonNext");

            // 返回
            UIbackButton.onClick.AddListener(() =>
            {
                SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.StaticCamera);

                UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.RoomPanel.ToString());
                //UIManager.Instance.OpenPanel(PanelName.GemPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });

            // 下一步
            UInextButton.onClick.AddListener(() =>
            {
                EventCenter.Instance.NotifyEvent(EventType.OnSelectPlayerComplete);
                UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.SelectingSkinPanel.ToString());
                UIMediator.Instance.ClosePanel(PanelName.SelectingPlayerPanel.ToString());
            });
        }

        private void InitData()
        {
            Transform temp = null;
            var playerSystem = SystemRepository.Instance.GetSystem<PlayerSystem>();
            var playerModel = playerSystem.GetPlayerModel(Enum.Parse<PlayerType>(playerSystem.playerGameObject.name));

            const int HPLimit = 12;
            const int armorLimit = 10;
            const int energyLimit = 320;
            const int criticalLimit = 10;

            // 生命
            temp = UnityTools.Instance.GetTransformFromChildren(gameObject, "DivHor1");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.maxHP / HPLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.maxHP.ToString();

            // 护甲
            temp = UnityTools.Instance.GetTransformFromChildren(gameObject, "DivHor2");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.maxArmor / armorLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.maxArmor.ToString();

            // 能量
            temp = UnityTools.Instance.GetTransformFromChildren(gameObject, "DivHor3");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.maxEnergy / energyLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.maxEnergy.ToString();

            // 暴击
            temp = UnityTools.Instance.GetTransformFromChildren(gameObject, "DivHor4");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.critical / criticalLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.critical.ToString();
        }
    }
}