using UnityEngine;

public class ICharacter
{
    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;

    private bool _isLeft;
    public bool isLeft
    {
        get => _isLeft;
        set
        {
            if (value)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 0);
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
    public void GameUpdate()
    {
        if(!isInit)
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
        if(!isStart)
        {
            isStart = true;
            OnCharacterStart();
        }
    }
    protected virtual void OnCharacterDieStart() { }
    protected virtual void OnCharacterDieUpdate() { }
    public void Remove()
    {

    }
}