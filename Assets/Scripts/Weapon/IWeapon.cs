using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class IWeapon
{
    public GameObject gameObject { get;protected set; }
    public Transform transform => gameObject.transform;
    protected ICharacter character;

    private bool isInit;
    private bool isEnter;
    public IWeapon(GameObject gameObject,ICharacter character)
    {
        this.gameObject = gameObject;
        this.character = character;
    }

    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }

        OnUpdate();
    }

    protected virtual void OnInit() { }
    // 每次切换至此武器时调用一次

    protected virtual void OnEnter() { }

    protected virtual void OnUpdate()
    {
        if(!isEnter)
        {
            isEnter = true;
            OnEnter();
        }
    }

    public virtual void OnExit()
    {
        isEnter = false;
    }

    // 发射时执行
    protected virtual void OnFire() { }
}