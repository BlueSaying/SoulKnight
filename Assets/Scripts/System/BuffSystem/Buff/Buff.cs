using UnityEngine;

public class Buff
{
    public Character owner { get; protected set; }

    private bool isInit;
    public bool isEnd { get; private set; }

    private float durationTimer = 0f;
    private float duration;

    public Buff(float duration, Character owner)
    {
        this.duration = duration;
        this.owner = owner;
    }

    protected virtual void OnInit() { }

    public virtual void OnUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        durationTimer += Time.deltaTime;
        if (durationTimer >= duration)
        {
            EndBuff();
        }
    }

    protected virtual void EndBuff()
    {
        isEnd = true;
    }
}