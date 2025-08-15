using UnityEngine.SceneManagement;

public class SceneModel : AbstractModel
{
    public int curSceneIndex => SceneManager.GetActiveScene().buildIndex;
    public SceneName curSceneName => (SceneName)curSceneIndex;
}