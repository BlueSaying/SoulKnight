using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// NOTE:组合模式 使用树形结构，使得客户端可以统一处理单个对象和组合对象
public abstract class BasePanel
{
    public GameObject panel { get; protected set; }
    public Transform transform => panel.transform;
    public RectTransform rectTransform { get; protected set; }

    protected BasePanel parent;
    protected List<BasePanel> children;

    // OPTIMIZE:使用状态机而替换bool变量
    private bool isInit;
    private bool isEnter;
    private bool isSuspend;
    protected bool isShowAfterExit;

    public BasePanel(BasePanel parent)
    {
        this.parent = parent;
        children = new List<BasePanel>();
    }

    // 由控制器调用以启用panel
    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        
        // 树形结构，用深度优先搜索去Update子物体
        foreach (var panel in children)
        {
            panel.GameUpdate();
        }

        if (!isSuspend)
        {
            OnUpdate();
        }
    }

    protected virtual void OnInit()
    {
        Suspend();

        if (panel == null)
        {
            GameObject mainCanvas = GameObject.Find("MainCanvas");
            if (mainCanvas != null)
            {
                panel = UnityTools.Instance.GetTransformFromChildren(mainCanvas, GetType().Name).gameObject;
                if (panel == null)
                {
                    throw new System.Exception("找不到名为" + GetType().ToString() + "的游戏物体!");
                }
            }
            else
            {
                throw new System.Exception("当前场景中不存在mainCanvas!");
            }
        }

        rectTransform = panel.GetComponent<RectTransform>();
    }

    protected virtual void OnEnter()
    {
        panel.SetActive(true);
    }

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public virtual void OnExit()
    {
        if (!isShowAfterExit)
        {
            panel.SetActive(false);
        }

        parent.isEnter = false;
        parent?.Resume();
        Suspend();
    }

    public void EnterPanel<T>() where T : BasePanel
    {
        BasePanel panel;

        try
        {
            panel = GetPanel<T>();
        }
        catch (System.IndexOutOfRangeException)
        {
            throw new System.Exception("无法进入类型为" + typeof(T).ToString() + "的界面，原因是未添加至children中!");
        }

        panel.Resume();
        panel.isEnter = false;
        Suspend();
    }

    // OPTIMIZE:使用字典缓存加速
    public T GetPanel<T>() where T : BasePanel
    {
        return children.Where(x => x is T).ToArray()[0] as T;
    }

    public void Suspend()
    {
        isSuspend = true;
    }

    public void Resume()
    {
        isSuspend = false;
    }
}
