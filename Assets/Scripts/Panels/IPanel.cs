using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// NOTE:组合模式 使用树形结构，使得客户端可以统一处理单个对象和组合对象
public abstract class IPanel
{
    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public RectTransform rectTransform { get; protected set; }

    protected IPanel parent;
    protected List<IPanel> children;

    private GameObject mainCanvas;

    private bool isInit;
    private bool isEnter;
    private bool isSuspend;
    protected bool isShowAfterExit;

    public IPanel(IPanel panel)
    {
        parent = panel;
        children = new List<IPanel>();
    }
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

        mainCanvas = GameObject.Find("MainCanvas");
        if (gameObject == null)
        {
            //gameObject = GameObject.Find(GetType().Name);
            gameObject = UnityTools.Instance.GetTransformFromChildren(mainCanvas, GetType().Name).gameObject;
        }

        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    protected virtual void OnEnter()
    {
        gameObject.SetActive(true);
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
            gameObject.SetActive(false);
        }

        parent.isEnter = false;
        parent.Resume();
        Suspend();
    }

    public void EnterPanel<T>() where T : IPanel
    {
        IPanel panel = GetPanel<T>();
        panel.Resume();
        panel.isEnter = false;
        Suspend();
    }

    public T GetPanel<T>() where T : IPanel
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
