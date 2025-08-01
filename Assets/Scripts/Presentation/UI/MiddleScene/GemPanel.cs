using UnityEngine.UI;
using UnityEngine;

namespace MiddleScene
{
    public class GemPanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            EventCenter.Instance.RegisterEvent(EventType.OnSelectSkinComplete, CloseGemPanel);
        }

        private void OnDestroy()
        {
            EventCenter.Instance.RemoveEvent(EventType.OnSelectSkinComplete, CloseGemPanel);
        }

        private void CloseGemPanel()
        {
            UIMediator.Instance.ClosePanel(PanelName.GemPanel.ToString());
        }
    }
}