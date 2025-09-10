using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFacade : Singleton<SceneFacade>
{
    private SceneModel sceneModel;
    private AsyncOperation op;

    private SceneFacade()
    {
        sceneModel = new SceneModel();
    }

    public void LoadScene(SceneName sceneName)
    {
        EventCenter.Instance.NotifyEvent(EventType.OnSceneSwitchStart);
        op = SceneManager.LoadSceneAsync((int)sceneName);
        op.completed += OnSceneSwitchComplete;
    }

    private void OnSceneSwitchComplete(AsyncOperation op)
    {
        EventCenter.Instance.ClearNonPermanentEvents();
        EventCenter.Instance.NotifyEvent(EventType.OnSceneSwitchComplete);
    }

    public SceneName GetActiveSceneName()
    {
        return sceneModel.curSceneName;
    }

    public int GetActiveSceneIndex()
    {
        return sceneModel.curSceneIndex;
    }
}