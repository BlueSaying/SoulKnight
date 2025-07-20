using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCommand : Singleton<SceneCommand>
{
    private SceneModel sceneModel;
    private AsyncOperation op;

    private SceneCommand()
    {
        sceneModel = ModelContainer.Instance.GetModel<SceneModel>();
    }

    public void LoadScene(SceneName sceneName)
    {
        EventCenter.Instance.NotifyEvent(EventType.OnSceneSwitchStart);
        op = SceneManager.LoadSceneAsync((int)sceneName);
        op.completed += OnSceneSwitchComplete;
    }

    private void OnSceneSwitchComplete(AsyncOperation op)
    {
        sceneModel.SetData();

        EventCenter.Instance.NotifyEvent(EventType.OnSceneSwitchComplete);
        EventCenter.Instance.ClearNonPermanentEvents();
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