using UnityEngine;

public class UISystem : AbstractSystem
{
    private Panel rootPanel;
    public UISystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        switch (SceneCommand.Instance.GetActiveSceneName())
        {
            case SceneName.MainMenuScene:
                rootPanel = new MainMenuScene.PanelRoot();
                break;
            case SceneName.MiddleScene:
                rootPanel = new MiddleScene.PanelRoot();
                break;
            case SceneName.BattleScene:
                //rootPanel = new BattleScene.PanelRoot();
                break;
        }
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        rootPanel.GameUpdate();
    }
}