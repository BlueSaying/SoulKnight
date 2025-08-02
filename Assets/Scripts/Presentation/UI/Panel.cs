using UnityEngine;

namespace MainMenuScene
{
    public enum PanelName
    {
        MainMenuPanel,
        KeyBoardPanel,
    }
}

namespace MiddleScene
{
    public enum PanelName
    {
        BattlePanel,
        GemPanel,
        RoomPanel,
        SelectingPlayerPanel,
        SelectingSkinPanel,
    }
}

namespace BattleScene
{
    public enum PanelName
    {

    }
}


/// <summary>
/// UI界面基类（需要调用UI_Manager来打开界面的需要继承此类）
/// </summary>
public class Panel : MonoBehaviour
{
    protected bool isRemove = false;
    protected new string name;

    protected virtual void Awake() { }
    
    protected virtual void Update() { }

    /// <summary>
    /// 打开UI界面
    /// </summary>
    /// <param name="panelName">UI界面的名称</param>
    public virtual void OpenPanel(string panelName)
    {
        name = panelName;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭UI界面
    /// </summary>
    public virtual void ClosePanel()
    {
        isRemove = true;
        gameObject.SetActive(false);
        Destroy(gameObject);

        //移除缓存，表示界面关闭
        //if (UIManager.Instance.panelDictionary.ContainsKey(name))//使用字典检查界面是否被打开
        //{
        //    UIManager.Instance.panelDictionary.Remove(name);
        //}
    }
}