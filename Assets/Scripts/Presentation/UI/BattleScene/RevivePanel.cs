using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class RevivePanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "BackButton").onClick.AddListener(EndGame);
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ReviveButton").onClick.AddListener(Revive);
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
            SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.Revive();
            UIMediator.Instance.ClosePanel(name);
        }
        #endregion
    }
}