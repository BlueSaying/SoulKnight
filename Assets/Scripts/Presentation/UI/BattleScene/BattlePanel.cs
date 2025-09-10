using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class BattlePanel : Panel
    {
        private Button pauseButton;

        private Player player;

        protected override void Start()
        {
            base.Start();

            pauseButton = transform.Find("RightPanel").Find("PauseButton").GetComponent<Button>();

            player = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
            RefreshPanel();

            EventCenter.Instance.RegisterEvent(EventType.UpdateBattlePanel, RefreshPanel);
            pauseButton.onClick.AddListener(OpenPausePanel);
        }

        private void OnDisable()
        {
            EventCenter.Instance.RemoveEvent(EventType.UpdateBattlePanel, RefreshPanel);
            pauseButton.onClick.RemoveListener(OpenPausePanel);
        }

        protected override void DOOpenPanel()
        {
            base.DOOpenPanel();
            (UnityTools.GetTransformFromChildren(gameObject, "PlayerStateBar") as RectTransform).DOAnchorPosX(-450, 0.5f).From();
            (UnityTools.GetTransformFromChildren(gameObject, "RightPanel") as RectTransform).DOAnchorPosX(800, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (UnityTools.GetTransformFromChildren(gameObject, "PlayerStateBar") as RectTransform).DOAnchorPosX(-450, 0.5f);
            (UnityTools.GetTransformFromChildren(gameObject, "RightPanel") as RectTransform).DOAnchorPosX(800, 0.5f)
                .OnComplete(DestroyPanel).OnKill(DestroyPanel);
        }

        #region 事件集
        private void RefreshPanel()
        {
            // Left Panel
            // refresh HP state
            Transform sliderHP = UnityTools.GetTransformFromChildren(gameObject, "SliderHP");
            sliderHP.GetComponent<Slider>().value = 1.0f * player.CurHP.Value / player.maxHP;
            sliderHP.Find("Text").GetComponent<Text>().text = player.CurHP.Value + " / " + player.maxHP;

            // refresh armor
            Transform sliderArmor = UnityTools.GetTransformFromChildren(gameObject, "SliderArmor");
            sliderArmor.GetComponent<Slider>().value = 1.0f * player.CurArmor.Value / player.maxArmor;
            sliderArmor.Find("Text").GetComponent<Text>().text = player.CurArmor.Value + " / " + player.maxArmor;

            // refresh energy
            Transform sliderEnergy = UnityTools.GetTransformFromChildren(gameObject, "SliderEnergy");
            sliderEnergy.GetComponent<Slider>().value = 1.0f * player.CurEnergy.Value / player.maxEnergy;
            sliderEnergy.Find("Text").GetComponent<Text>().text = player.CurEnergy.Value + " / " + player.maxEnergy;

            // Right Panel
            // refresh gold
            Transform rightPanel = transform.Find("RightPanel");
            rightPanel.Find("Gold").Find("Text").GetComponent<Text>().text = SystemRepository.Instance.GetSystem<GlobalSystem>().Gold.ToString();
        }

        private void OpenPausePanel()
        {
            UIMediator.Instance.OpenPanel(SceneName.Generic, Generic.PanelName.PausePanel.ToString());
            GamePauseFacade.Instance.PauseGame();
        }
        #endregion
    }
}