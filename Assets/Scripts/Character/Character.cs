using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public CharacterModel model { get; protected set; }

    public GameObject gameObject { get; protected set; }
    public Transform transform => gameObject.transform;
    public Rigidbody2D rb;
    public GameObject trigger { get; protected set; }
    public GameObject buffIcon { get; protected set; }

    // Buff不可叠加,故使用字典
    public Dictionary<BuffType, Buff> buffs { get; protected set; }

    #region Attr
    // 静态属性
    public string name => model.staticAttr.name;
    public int maxHP => model.staticAttr.maxHP;
    public float speed => model.staticAttr.speed;

    // 动态属性
    public DynamicAttr<int> CurHP
    {
        get
        {
            return model.dynamicAttr.curHP;
        }
    }
    public DynamicAttr<float> CurSpeed
    {
        get
        {
            return model.dynamicAttr.curSpeed;
        }
    }
    #endregion

    private bool isInit;
    private bool isEnter;

    public bool isDead { get; protected set; }

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

        try
        {
            buffIcon = UnityTools.Instance.GetTransformFromChildren(gameObject, "BuffIcon").gameObject;
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的BuffIcon子物体,请检查是否已经添加");
        }

        buffs = new Dictionary<BuffType, Buff>();
    }

    protected virtual void OnInit() { }

    protected virtual void OnEnter() { }

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

        ManageBuff();
    }

    private void ManageBuff()
    {
        // 记录当前是否还有buff
        bool hasBuff = false;

        foreach (var buff in buffs.Values)
        {
            if (!buff.isEnd)
            {
                buff.OnUpdate();

                // 如果buff.OnUpdate结束后,buff仍没结束
                if (!buff.isEnd)
                {
                    hasBuff = true;
                    buffIcon.GetComponent<SpriteRenderer>().sprite = ResourcesLoader.Instance.LoadSprite(buff.ToString());
                }
            }
        }

        buffIcon.SetActive(hasBuff);
    }

    public void AddBuff(BuffType buffType)
    {
        if (buffType == BuffType.None) return;

        if (buffs.ContainsKey(buffType))
        {
            if (buffs[buffType].isEnd)
            {
                buffs[buffType] = BuffFactory.CreateBuff(buffType, this);
            }
        }
        else
        {
            buffs.Add(buffType, BuffFactory.CreateBuff(buffType, this));
        }
    }
}