using UnityEngine.UI;
using UnityEngine;

namespace MiddleScene
{
    public class GemPanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            EventCenter.Instance.RigisterEvent(EventType.OnSelectSkinComplete, false, () =>
            {
                UIManager.Instance.ClosePanel(PanelName.GemPanel.ToString());
            });
        }
    }
}