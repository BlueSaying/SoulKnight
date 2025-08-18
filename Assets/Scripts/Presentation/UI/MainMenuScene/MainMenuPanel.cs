using UnityEngine.UI;

namespace MainMenuScene
{
    public class MainMenuPanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            InitUI();
        }

        private void InitUI()
        {
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonStart").onClick.AddListener(() =>
            {
                SceneFacade.Instance.LoadScene(SceneName.MiddleScene);
            });

            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonSetting").onClick.AddListener(() =>
            {
                UIMediator.Instance.OpenPanel(SceneName.MainMenuScene, PanelName.KeyBoardPanel.ToString());
            });
        }
    }
}