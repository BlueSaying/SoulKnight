using UnityEngine;

public abstract class Item
{
    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public Vector2 position { get => transform.position; set => transform.position = value; }
    public Quaternion rotation { get => transform.rotation; set => transform.rotation = value; }

    private bool isInit;
    private bool isEnter;
    public bool isRemoved { get; protected set; }

    public Item(GameObject gameObject)
    {
        this.gameObject = gameObject;

        // 托管至ItemSystem
        ManagedToController();
    }

    protected virtual void OnInit() { }

    public virtual void OnEnter() { }

    public virtual void OnFixedUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public virtual void OnUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public void Remove()
    {
        isRemoved = true;

        // 放入对象池
        SystemRepository.Instance.GetSystem<ItemSystem>().itemPool.ReleaseItem(this);
    }

    // 将*this*托管到ItemController中
    public void ManagedToController()
    {
        SystemRepository.Instance.GetSystem<ItemSystem>().AddActiveItem(this);
    }

    public virtual void Reset()
    {
        isEnter = false;
        isRemoved = false;
    }
}