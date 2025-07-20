using UnityEngine.UI;
using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuPanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonStart")
                .onClick.AddListener(() => { SceneCommand.Instance.LoadScene(SceneName.MiddleScene); });
        }
    }
}