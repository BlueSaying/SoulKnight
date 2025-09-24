using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class GemPanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            transform.Find("Gem").Find("GemText").GetComponent<Text>().text = SaveManager.Instance.GlobalData.GemCount.ToString();

            // TODO:未来移除
            SaveManager.Instance.SaveData();
        }

        protected override void DOOpenPanel()
        {
            base.DOOpenPanel();
            (UnityTools.GetTransformFromChildren(gameObject, "Gem") as RectTransform).DOAnchorPosY(100, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (UnityTools.GetTransformFromChildren(gameObject, "Gem") as RectTransform).DOAnchorPosY(100, 0.5f)
                .OnComplete(DestroyPanel).OnKill(DestroyPanel);
        }
    }
}