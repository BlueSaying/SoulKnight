using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class RevivePanel : Panel
    {
        private int reviveCost;
        private Text ReviveCostText;

        protected override void Awake()
        {
            base.Awake();

            transform.Find("Gem").Find("GemText").GetComponent<Text>().text = SaveManager.Instance.GlobalData.GemCount.ToString();

            ReviveCostText = transform.Find("ChoosePanel").Find("BottomPanel").Find("ReviveButton").Find("Text").GetComponent<Text>();
            UnityTools.GetComponentFromChildren<Button>(gameObject, "BackButton").onClick.AddListener(EndGame);
            UnityTools.GetComponentFromChildren<Button>(gameObject, "ReviveButton").onClick.AddListener(Revive);

            reviveCost = TestManager.FreeRevive ? 0 : SystemRepository.Instance.GetSystem<PlayerSystem>().ReviveCost;
            ReviveCostText.text = reviveCost.ToString();
        }

        protected override void DOOpenPanel()
        {
            base.DOOpenPanel();
            (transform.Find("ChoosePanel") as RectTransform).DOAnchorPosY(-1000, 0.5f).From();
            (transform.Find("Gem") as RectTransform).DOAnchorPosY(200, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (transform.Find("ChoosePanel") as RectTransform).DOAnchorPosY(-1000, 0.5f);
            (transform.Find("Gem") as RectTransform).DOAnchorPosY(200, 0.5f).OnComplete(DestroyPanel).OnKill(DestroyPanel);
        }

        #region 事件集
        private void EndGame()
        {
            SceneFacade.Instance.LoadScene(SceneName.MainMenuScene);
        }

        private void Revive()
        {
            if (SaveManager.Instance.GlobalData.GemCount < reviveCost) return;

            SaveManager.Instance.GlobalData.GemCount -= reviveCost;
            SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.Revive();
            UIMediator.Instance.ClosePanel(name);
        }
        #endregion
    }
}