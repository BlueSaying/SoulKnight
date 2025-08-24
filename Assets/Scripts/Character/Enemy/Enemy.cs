using System.Collections;
using UnityEngine;

public abstract class Enemy : Character, IDamageable
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

    public Weapon weapon { get; protected set; }

    protected EnemyFSM stateMachine;

    // 当前是否为受击闪烁状态
    private bool isFlashing;

    public Enemy(GameObject obj, EnemyModel model) : base(obj, model) { }

    public override void OnUpdate()
    {
        base.OnUpdate();
        stateMachine?.OnUpdate();
    }

    // call it when get hurt
    public virtual void TakeDamage(int damage, Color damageColor)
    {
        // 弹出伤害值
        Transform damageNumPoint = transform.Find("DamageNumPoint");
        ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint.position, damage, damageColor);

        CurHP -= damage;

        if (CurHP <= 0)
        {
            Die();
        }

        if (!isFlashing)
        {
            CoroutinePool.Instance.StartCoroutine(this, BeWhite());
        }
    }

    // be white when get hurt
    private IEnumerator BeWhite()
    {
        isFlashing = true;

        SpriteRenderer render = transform.Find("Sprite").GetComponent<SpriteRenderer>();

        float timer = 0f;
        float time = 0.15f;
        while (timer < time)
        {
            render.color = new Color(render.color.r, render.color.g, render.color.b, 1 - timer / time);
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
        if (isDead) return;
        isDead = true;

        // 播放音效
        AudioManager.Instance.PlaySound(AudioType.Hurt, (AudioName)(AudioName.fx_hit_p1 + Random.Range(0, 5)));

        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        Animator.SetTrigger("Die");
        transform.Find("Collider").gameObject.SetActive(false);
        transform.Find("Trigger").gameObject.SetActive(false);

        SystemRepository.Instance.GetSystem<EnemySystem>().enemies.Remove(this);

        EventCenter.Instance.NotifyEvent(EventType.OnEnemyDie);
        //CoroutinePool.Instance.StopAllCoroutine(this);
    }

    public float DistanceToTargetPlayer()
    {
        Player targetPlayer = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
        float x = (targetPlayer.transform.position.x - transform.position.x);
        float y = (targetPlayer.transform.position.y - transform.position.y);
        return x * x + y * y;
    }

    // Add a weapon to this enemy
    public void AddWeapon(WeaponModel model)
    {
        if (model == null) return;

        weapon = WeaponFactory.Instance.GetWeapon(model, this);
    }
}