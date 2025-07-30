using UnityEngine.UI;
using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuPanel : Panel
    {
        Button UIstartButton;

        protected override void Awake()
        {
            base.Awake();

            InitUI();
        }

        private void InitUI()
        {
            UIstartButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonStart");

            UIstartButton.onClick.AddListener(() =>
            {
                SceneFacade.Instance.LoadScene(SceneName.MiddleScene);
            });
        }
    }
}