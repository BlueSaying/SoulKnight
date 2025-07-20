using UnityEngine.UI;
using UnityEngine;

namespace MainMenuScene
{
    public class PanelRoot : Panel
    {
        public PanelRoot() : base(null) { }
        protected override void OnInit()
        {
            base.OnInit();
            UnityTools.Instance.GetComponentFromChildren<Button>(panel, "ButtonStart")
                .onClick.AddListener(() => { SceneCommand.Instance.LoadScene(SceneName.MiddleScene); });
        }
        protected override void OnEnter()
        {
            base.OnEnter();
        }
    }

}