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
            SaveManager.Instance.SaveData();
        }

        protected override void DOOpenPanel()
        {
            base.DOOpenPanel();
            (UnityTools.Instance.GetTransformFromChildren(gameObject, "Gem") as RectTransform).DOAnchorPosY(100, 0.5f).From();
        }

        protected override void DOClosePanel()
        {
            base.DOClosePanel();
            (UnityTools.Instance.GetTransformFromChildren(gameObject, "Gem") as RectTransform).DOAnchorPosY(100, 0.5f).OnComplete(() =>
            {
                DestroyPanel();
            });
        }
    }
}