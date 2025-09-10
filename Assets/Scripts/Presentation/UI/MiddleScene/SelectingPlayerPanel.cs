using DG.Tweening;
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

            InitPanel();

            UIbackButton = UnityTools.GetComponentFromChildren<Button>(gameObject, "ButtonBack");
            UInextButton = UnityTools.GetComponentFromChildren<Button>(gameObject, "ButtonNext");

            // 返回
            UIbackButton.onClick.AddListener(() =>
            {
                SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.StaticCamera);

                UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.RoomPanel.ToString());
                UIMediator.Instance.OpenPanel(SceneName.MiddleScene, PanelName.GemPanel.ToString());
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

        protected override void DOOpenPanel()
        {
            base.DOOpenPanel();
            (UnityTools.GetTransformFromChildren(gameObject, "Title") as RectTransform).DOAnchorPosY(100, 0.5f).From();
            (UnityTools.GetTransformFromChildren(gameObject, "LeftPanel") as RectTransform).DOAnchorPosX(-600f, 0.5f).From();
            (UnityTools.GetTransformFromChildren(gameObject, "RightPanel") as RectTransform).DOAnchorPosX(600f, 0.5f).From();
            (UnityTools.GetTransformFromChildren(gameObject, "ButtonBack") as RectTransform).DOAnchorPosX(-300f, 0.5f).From();
            (UnityTools.GetTransformFromChildren(gameObject, "ButtonNext") as RectTransform).DOAnchorPosX(300f, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (UnityTools.GetTransformFromChildren(gameObject, "Title") as RectTransform).DOAnchorPosY(100, 0.5f);
            (UnityTools.GetTransformFromChildren(gameObject, "LeftPanel") as RectTransform).DOAnchorPosX(-600f, 0.5f);
            (UnityTools.GetTransformFromChildren(gameObject, "RightPanel") as RectTransform).DOAnchorPosX(600f, 0.5f);
            (UnityTools.GetTransformFromChildren(gameObject, "ButtonBack") as RectTransform).DOAnchorPosX(-300f, 0.5f);
            (UnityTools.GetTransformFromChildren(gameObject, "ButtonNext") as RectTransform).DOAnchorPosX(300f, 0.5f)
                .OnComplete(DestroyPanel).OnKill(DestroyPanel);
        }

        private void InitPanel()
        {
            Transform temp = null;
            var playerSystem = SystemRepository.Instance.GetSystem<PlayerSystem>();
            PlayerType playerType = Enum.Parse<PlayerType>(playerSystem.playerGameObject.name);
            PlayerModel playerModel = playerSystem.GetPlayerModel(playerType);

            // Title
            transform.Find("Title").Find("Text").GetComponent<Text>().text = playerType.ToString().ToChinese();

            // LeftPanel
            const int HPLimit = 12;
            const int armorLimit = 10;
            const int energyLimit = 320;
            const int criticalLimit = 10;

            // 生命
            temp = UnityTools.GetTransformFromChildren(gameObject, "DivHor1");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.maxHP / HPLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.maxHP.ToString();

            // 护甲
            temp = UnityTools.GetTransformFromChildren(gameObject, "DivHor2");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.maxArmor / armorLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.maxArmor.ToString();

            // 能量
            temp = UnityTools.GetTransformFromChildren(gameObject, "DivHor3");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.maxEnergy / energyLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.maxEnergy.ToString();

            // 暴击
            temp = UnityTools.GetTransformFromChildren(gameObject, "DivHor4");
            temp.Find("Slider").GetComponent<Slider>().value = 1.0f * playerModel.staticAttr.critical / criticalLimit;
            temp.Find("Text").GetComponent<Text>().text = playerModel.staticAttr.critical.ToString();

            // 初始武器
            transform.Find("DivMain").Find("LeftPanel").Find("DivBottom").Find("DivRight").Find("DefaultWeapon").GetComponent<Image>().sprite =
                ResourcesLoader.Instance.LoadSprite(SpriteType.Weapon.ToString(), playerModel.staticAttr.defaultWeaponType.ToString());

            // RightPanel
            
            //temp = transform.Find("DivMain").Find("RightPanel");
        }
    }
}