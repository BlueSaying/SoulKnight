using UnityEngine;

public class Character
{
    public CharacterModel model { get; protected set; }

    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public Rigidbody2D rb;

    public GameObject trigger { get; protected set; }

    public bool isLeft { get; private set; }
    protected bool isLeftAuto = false;
    public void ChangeLeft(bool isLeft, bool isAuto)
    {
        if (isLeftAuto && !isAuto) return;
        isLeftAuto = isAuto;

        if (isLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        this.isLeft = isLeft;
    }

    private bool isInit;
    private bool isStart;

    public Character(GameObject obj, CharacterModel model)
    {
        gameObject = obj;
        this.model = model;

        try
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的RigidBody2D组件,请检查是否已经添加");
        }

        try
        {
            trigger = UnityTools.Instance.GetTransformFromChildren(gameObject, "Trigger").gameObject;
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的Trigger子物体,请检查是否已经添加");
        }

    }

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        OnCharacterUpdate();
    }

    protected virtual void OnInit() { }

    protected virtual void OnCharacterStart() { }

    protected virtual void OnCharacterUpdate()
    {
        if (!isStart)
        {
            isStart = true;
            OnCharacterStart();
        }
    }
}