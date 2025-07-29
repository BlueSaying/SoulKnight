using UnityEngine;

public class UIRenderer
{
    //根节点
    private Transform _uiRoot;
    public Transform UIRoot
    {
        get
        {
            if (_uiRoot == null) _uiRoot = GameObject.Find("MainCanvas").transform;
            if (_uiRoot == null) throw new System.Exception("未找到MainCanvas");
            return _uiRoot;
        }
    }

    private static UIRenderer _instance;
    public static UIRenderer Instance
    {
        get
        {
            if (_instance == null) _instance = new UIRenderer();
            return _instance;
        }
    }

    //构造函数
    private UIRenderer() { }

    public Panel InstantiatePanel(string panelName)
    {
        //使用缓存的预制件
        string curSceneName = SceneFacade.Instance.GetActiveSceneName().ToString();
        GameObject panelPrefab = ResourcesLoader.Instance.LoadPanel(curSceneName, panelName);

        //打开UI界面
        GameObject panelObject = Object.Instantiate(panelPrefab, UIRoot, false);    //从预制体中实例化一个新的界面
        Panel panel = panelObject.GetComponent<Panel>();

        if (panel == null)
        {
            throw new System.Exception(panel.ToString() + "未添加Panel或其子类");
        }

        panel.OpenPanel(panelName);

        return panel;
    }

    public void DestroyPanel(Panel panel)
    {
        panel.ClosePanel();
    }

    // 将UI面板上移一层
    public void MovePanelUp(Panel panel)
    {
        int siblingIndex = panel.transform.GetSiblingIndex();
        if (siblingIndex > 0) panel.transform.SetSiblingIndex(siblingIndex - 1);
    }

    // 将UI面板下移一层
    public void MovePanelDown(Panel panel)
    {
        int siblingCount = panel.transform.parent.childCount;
        int siblingIndex = panel.transform.GetSiblingIndex();
        if (siblingIndex < siblingCount - 1) panel.transform.SetSiblingIndex(siblingIndex + 1);
    }

    // 将UI面板移动到最前面
    public void MovePanelToFront(Panel panel)
    {
        panel.transform.SetAsFirstSibling();
    }

    // 将UI面板移动到最后面
    public void MovePanelToBack(Panel panel)
    {
        panel.transform.SetAsLastSibling();
    }
}