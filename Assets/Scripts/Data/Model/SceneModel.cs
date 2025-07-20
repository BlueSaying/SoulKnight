using UnityEngine.SceneManagement;

public enum SceneName
{
    MainMenuScene,
    MiddleScene,
    BattleScene,
}

public class SceneModel : AbstractModel
{
    public SceneName curSceneName;
    public int curSceneIndex;

    protected override void OnInit()
    {
        base.OnInit();
        SetData();
    }

    public void SetData()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;

        curSceneName = (SceneName)curSceneIndex;
    }
}