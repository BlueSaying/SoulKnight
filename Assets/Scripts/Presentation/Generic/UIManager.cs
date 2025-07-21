using System.Collections.Generic;
using UnityEngine;

public class UIManager
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

    /// <summary>
    /// 储存已经打开界面的缓存字典
    /// </summary>
    public Dictionary<string, Panel> panelDictionary;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null) _instance = new UIManager();
            return _instance;
        }
    }

    //构造函数
    private UIManager()
    {
        EventCenter.Instance.ReigisterEvent(EventType.OnSceneSwitchStart, false, () =>
        {
            panelDictionary.Clear();
        });

        InitDictionary();
    }

    /// <summary>
    /// 初始化UI字典数据
    /// </summary>
    private void InitDictionary()
    {
        // 界面名称，界面类
        panelDictionary = new Dictionary<string, Panel>();
    }

    /// <summary>
    /// 检测UI界面是否被打开
    /// </summary>
    /// <param name="panelname">要检测的UI界面的名称</param>
    /// <returns>若界面已打开则返回true,反之返回false</returns>
    public bool IsPanelOpened(string panelname)
    {
        return panelDictionary.ContainsKey(panelname);
    }

    /// <summary>
    /// 打开UI界面
    /// </summary>
    /// <param name="panelName">要打开的UI界面的名称</param>
    /// <returns>打开的界面的Base_Panel</returns>
    public Panel OpenPanel(string panelName)
    {
        Panel panel = null;
        //检查是否已经打开
        if (panelDictionary.TryGetValue(panelName, out panel))
        {
            Debug.Log("界面已打开" + panelName);
            return null;
        }

        //使用缓存的预制件
        string curSceneName = SceneCommand.Instance.GetActiveSceneName().ToString();
        GameObject panelPrefab = ResourcesLoader.Instance.GetPanel(curSceneName, panelName);

        //打开UI界面
        GameObject panelObject = Object.Instantiate(panelPrefab, UIRoot, false);    //从预制体中实例化一个新的界面
        panel = panelObject.GetComponent<Panel>();

        if (panel == null)
        {
            throw new System.Exception(panel.ToString() + "未添加Panel或其子类");
        }

        panelDictionary.Add(panelName, panel);
        panel.OpenPanel(panelName);
        return panel;
    }

    /// <summary>
    /// 关闭UI界面
    /// </summary>
    /// <param name="panelname">要关闭的UI界面的名称</param>
    /// <returns>是否成功打开UI界面</returns>
    public bool ClosePanel(string panelname)
    {
        Panel panel = null;
        if (!panelDictionary.TryGetValue(panelname, out panel))//检测要关闭的界面有没有被打开
        {
            Debug.LogError("界面未打开" + panelname);
            return false;
        }

        panelDictionary.Remove(panelname);
        panel.ClosePanel();
        return true;
    }
}