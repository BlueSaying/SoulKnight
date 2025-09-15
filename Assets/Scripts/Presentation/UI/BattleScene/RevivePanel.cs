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

            ReviveCostText = transform.Find("BottomPanel").Find("ReviveButton").Find("Text").GetComponent<Text>();
            UnityTools.GetComponentFromChildren<Button>(gameObject, "BackButton").onClick.AddListener(EndGame);
            UnityTools.GetComponentFromChildren<Button>(gameObject, "ReviveButton").onClick.AddListener(Revive);

            reviveCost = TestManager.FreeRevive ?
                0 : SystemRepository.Instance.GetSystem<PlayerSystem>().ReviveCost;
            ReviveCostText.text = reviveCost.ToString();
        }

        protected override void DOOpenPanel()
        {
            base.DOOpenPanel();
            (transform as RectTransform).DOAnchorPosY(-1000, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (transform as RectTransform).DOAnchorPosY(-1000, 0.5f).OnComplete(DestroyPanel).OnKill(DestroyPanel);
        }

        #region 事件集
        private void EndGame()
        {
            SceneFacade.Instance.LoadScene(SceneName.MainMenuScene);
        }

        private void Revive()
        {
            SaveManager.Instance.GlobalData.GemCount -= reviveCost;
            SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.Revive();
            UIMediator.Instance.ClosePanel(name);
        }
        #endregion
    }
}