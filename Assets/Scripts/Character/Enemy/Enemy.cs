using System.Collections;
using UnityEngine;

public enum EnemyType
{
    Boar,
    DireBoar,
    GoblinGuard,
    EliteGoblinGuard,
    GoblinShaman,
    TrumpetFlower,
    GunShark,
    GoblinGiant,
    Stake,
}

public class Enemy : Character, IDamageable
{
    public new EnemyModel model { get => base.model as EnemyModel; set => base.model = value; }
    
    protected Animator animator;
    protected Animator Animator
    {
        get
        {
            if (animator == null) animator = transform.Find("Sprite").GetComponent<Animator>();
            if (animator == null) throw new System.Exception("无法找到Animator");
            return animator;
        }
    }

    private bool isDead = false;
    //protected PlayerStateMachine stateMachine;

    //protected List<BasePlayerWeapon> weapons;
    //protected BasePlayerWeapon usingWeapon;

    // 当前是否为受击闪烁状态
    //private bool isFlashing = false;

    public Enemy(GameObject obj, EnemyModel model) : base(obj, model) { }

    protected override void OnCharacterDieStart()
    {
        base.OnCharacterDieStart();
        CoroutinePool.Instance.StopAllCoroutine(this);
    }

    public virtual void TakeDamage(int damage, Color damageColor)
    {
        // HACK
        Transform damageNumPoint = transform.Find("DamageNumPoint");

        DamageNum damageNum = ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint, damage, damageColor);
        damageNum.ManagedToController();

        Animator.SetTrigger("BeAttack");

        model.dynamicAttr.curHP -= damage;
        //Debug.Log("剩余血量:" + model.dynamicAttr.curHP);
        if (model.dynamicAttr.curHP <= 0)
        {
            Die();
        }
        //if (!isFlashing)
        //{
        //    CoroutinePool.Instance.StartCoroutine(this, BeWhite());
        //}

        //dynamicAttr.Hp -= damage;
    }

    //private IEnumerator BeWhite()
    //{
    //    isFlashing = true;
    //
    //    SpriteRenderer render = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    //
    //    render.color = new Color(render.color.r, render.color.g, render.color.b, 0.5f);
    //
    //    yield return new WaitForSeconds(0.05f);
    //
    //    render.color = new Color(render.color.r, render.color.g, render.color.b, 1f);
    //
    //    isFlashing = false;
    //}

    public virtual void Die()
    {
        if(isDead)
        {
            return;
        }
        else
        {
            isDead = true;
        }
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetTrigger("Die");
        transform.Find("Collider").gameObject.SetActive(false);
        transform.Find("Trigger").gameObject.SetActive(false);
        EventCenter.Instance.NotifyEvent(EventType.OnEnemyDie);
    }
}