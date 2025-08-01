using UnityEngine;

public class Item
{
    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public Vector2 position { get => transform.position; set => transform.position = value; }
    public Quaternion rotation { get => transform.rotation; set => transform.rotation = value; }

    private bool isInit;
    private bool isEnter;
    private bool beingRemoved;
    public bool hasRemoved { get; protected set; }

    public Item(GameObject gameObject)
    {
        this.gameObject = gameObject;

        // 托管至ItemSystem
        ManagedToController();
    }

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        if (beingRemoved && !hasRemoved)
        {
            OnExit();
            hasRemoved = true;
        }

        OnUpdate();
    }

    protected virtual void OnInit() { }

    public virtual void OnEnter()
    {
        beingRemoved = false;
        hasRemoved = false;
    }

    protected virtual void OnUpdate()
    {
        if (!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    protected virtual void OnExit() { }

    public void Remove()
    {
        beingRemoved = true;
    }

    // 将*this*托管到ItemController中
    public void ManagedToController()
    {
        SystemRepository.Instance.GetSystem<ItemSystem>().AddItem(this);
    }
}