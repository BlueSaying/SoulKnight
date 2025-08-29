using UnityEngine;

/// <summary>
/// UI界面基类（需要调用UIMediator来打开界面的需要继承此类）
/// </summary>
public class Panel : MonoBehaviour
{
    protected bool isRemove = false;
    protected new string name;

    protected virtual void Awake() { }

    protected virtual void Start() { }

    protected virtual void Update() { }

    /// <summary>
    /// 打开UI界面
    /// </summary>
    /// <param name="panelName">UI界面的名称</param>
    public virtual void OpenPanel(string panelName)
    {
        name = panelName;
        //gameObject.SetActive(true);
        DOOpenPanel();
    }

    /// <summary>
    /// 关闭UI界面
    /// </summary>
    public virtual void ClosePanel()
    {
        DOClosePanel();
    }

    protected virtual void DOOpenPanel() { }

    protected virtual void DOClosePanel() { }

    protected void DestroyPanel()
    {
        isRemove = true;
        //gameObject.SetActive(false);

        Destroy(gameObject);
    }
}