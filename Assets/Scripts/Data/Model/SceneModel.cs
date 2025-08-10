using UnityEngine.SceneManagement;

public enum SceneName
{
    /// <summary>
    /// 主菜单
    /// </summary>
    MainMenuScene,

    /// <summary>
    /// 大厅
    /// </summary>
    MiddleScene,

    /// <summary>
    /// 战斗场景
    /// </summary>
    BattleScene,
}

public class SceneModel : AbstractModel
{
    public int curSceneIndex => SceneManager.GetActiveScene().buildIndex;
    public SceneName curSceneName => (SceneName)curSceneIndex;
}