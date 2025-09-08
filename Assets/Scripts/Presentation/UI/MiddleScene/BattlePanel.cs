using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class BattlePanel : Panel
    {
        private Button pauseButton;

        private Player player;

        protected override void Awake()
        {
            base.Awake();

            pauseButton = transform.Find("RightPanel").Find("PauseButton").GetComponent<Button>();
            SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.FollowCamera);

            // 设置相机跟随目标
            Transform mainPlayerTransform = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.transform;
            SystemRepository.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.FollowCamera, mainPlayerTransform);

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
            (UnityTools.Instance.GetTransformFromChildren(gameObject, "PlayerStatePanel") as RectTransform).DOAnchorPosX(-400, 0.5f).From();
            (UnityTools.Instance.GetTransformFromChildren(gameObject, "RightPanel") as RectTransform).DOAnchorPosX(800, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (UnityTools.Instance.GetTransformFromChildren(gameObject, "PlayerStatePanel") as RectTransform).DOAnchorPosX(-400, 0.5f);
            (UnityTools.Instance.GetTransformFromChildren(gameObject, "RightPanel") as RectTransform).DOAnchorPosX(800, 0.5f)
                .OnComplete(DestroyPanel).OnKill(DestroyPanel);
        }

        #region 事件集
        private void RefreshPanel()
        {
            // Left Panel
            // refresh HP state
            Transform sliderHP = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderHP");
            sliderHP.GetComponent<Slider>().value = 1.0f * player.CurHP.Value / player.maxHP;
            sliderHP.Find("Text").GetComponent<Text>().text = player.CurHP.Value + " / " + player.maxHP;

            // refresh armor
            Transform sliderArmor = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderArmor");
            sliderArmor.GetComponent<Slider>().value = 1.0f * player.CurArmor.Value / player.maxArmor;
            sliderArmor.Find("Text").GetComponent<Text>().text = player.CurArmor.Value + " / " + player.maxArmor;

            // refresh energy
            Transform sliderEnergy = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderEnergy");
            sliderEnergy.GetComponent<Slider>().value = 1.0f * player.CurEnergy.Value / player.maxEnergy;
            sliderEnergy.Find("Text").GetComponent<Text>().text = player.CurEnergy.Value + " / " + player.maxEnergy;

            // Right Panel
            // refresh gem & gold
            Transform rightPanel = transform.Find("RightPanel");
            rightPanel.Find("Gem").Find("Text").GetComponent<Text>().text = SaveManager.Instance.GlobalData.GemCount.ToString();
            rightPanel.Find("Gold").Find("Text").GetComponent<Text>().text = SystemRepository.Instance.GetSystem<GlobalSystem>().Gold.ToString();
        }

        private void OpenPausePanel()
        {
            // TODO:open pause panel
            Debug.Log("OpenPausePanel");
        }
        #endregion
    }
}