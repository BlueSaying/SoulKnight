using System.Collections.Generic;
using UnityEngine;

public class UIMediator : Singleton<UIMediator>
{
    // 储存已经打开界面的缓存字典
    public Dictionary<string, Panel> panelDictionary;

    private UIMediator()
    {
        EventCenter.Instance.RegisterEvent(EventType.OnSceneSwitchStart, true, () =>
        {
            panelDictionary.Clear();
        });

        InitDictionary();
    }

    // 初始化UI字典数据
    private void InitDictionary()
    {
        // 界面名称，界面类
        panelDictionary = new Dictionary<string, Panel>();
    }

    // 检测UI界面是否被打开
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

        panel = UIRenderer.Instance.InstantiatePanel(panelName);

        panelDictionary.Add(panelName, panel);

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
        UIRenderer.Instance.DestroyPanel(panel);
        return true;
    }
}