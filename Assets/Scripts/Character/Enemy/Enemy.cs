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

    protected EnemyStateMachine stateMachine;

    private bool isDead = false;

    // 当前是否为受击闪烁状态
    private bool isFlashing = false;

    public Enemy(GameObject obj, EnemyModel model) : base(obj, model) { }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        stateMachine?.GameUpdate();
    }

    public virtual void TakeDamage(int damage, Color damageColor)
    {
        // HACK
        Transform damageNumPoint = transform.Find("DamageNumPoint");

        DamageNum damageNum = ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint, damage, damageColor);

        model.dynamicAttr.curHP -= damage;

        if (model.dynamicAttr.curHP <= 0)
        {
            Die();
        }
        if (!isFlashing)
        {
            CoroutinePool.Instance.StartCoroutine(this, BeWhite());
        }
    }

    private IEnumerator BeWhite()
    {
        isFlashing = true;

        SpriteRenderer render = transform.Find("Sprite").GetComponent<SpriteRenderer>();

        float timer = 0f;
        float time = 0.15f;
        while(timer< time)
        {
            render.color = new Color(render.color.r, render.color.g, render.color.b, 1-timer/time);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;

        while (timer < time)
        {
            render.color = new Color(render.color.r, render.color.g, render.color.b, timer / time);
            timer += Time.deltaTime;
            yield return null;
        }

        isFlashing = false;
    }

    public virtual void Die()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            isDead = true;
        }

        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        Animator.SetTrigger("Die");
        transform.Find("Collider").gameObject.SetActive(false);
        transform.Find("Trigger").gameObject.SetActive(false);

        SystemRepository.Instance.GetSystem<EnemySystem>().enemies.Remove(this);

        EventCenter.Instance.NotifyEvent(EventType.OnEnemyDie);
        //CoroutinePool.Instance.StopAllCoroutine(this);
    }
}