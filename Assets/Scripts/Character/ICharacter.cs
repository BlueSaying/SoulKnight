using UnityEngine;

public class ICharacter
{
    public CharacterStaticAttr staticAttr { get;protected set; }
    public CharacterDynamicAttr dynamicAttr { get; protected set; }

    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public Rigidbody2D rb => gameObject.GetComponent<Rigidbody2D>();

    private bool _isLeft;
    public bool isLeft
    {
        get => _isLeft;
        set
        {
            if (value)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
            _isLeft = value;

        }
    }

    private bool isInit;
    private bool isStart;
    private bool isShouldRemove;
    private bool isAlreadyRemove;

    public ICharacter(GameObject obj)
    {
        gameObject = obj;
    }

    public void SetDynamicAttr(CharacterDynamicAttr dynamicAttr)
    {
        this.dynamicAttr = dynamicAttr;
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
    protected virtual void OnCharacterDieStart() { }

    protected virtual void OnCharacterDieUpdate() { }

    public void Remove()
    {
        isShouldRemove = true;
    }
}