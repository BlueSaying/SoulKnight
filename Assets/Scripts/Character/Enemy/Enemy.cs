using System.Collections;
using UnityEngine;

public abstract class Enemy : Character, IDamageable
{
    public new EnemyModel model { get => base.model as EnemyModel; set => base.model = value; }

    public Weapon weapon { get; protected set; }

    protected EnemyFSM stateMachine;

    // 当前是否为受击闪烁状态
    private bool isFlashing;

    private bool isInvincible;
    public bool IsInvincible { get => isInvincible; set => isInvincible = value; }

    public Enemy(GameObject obj, EnemyModel model) : base(obj, model) { }

    public override void OnUpdate()
    {
        if (isDead) return;

        base.OnUpdate();
        stateMachine?.OnUpdate();
    }

    // call it when get hurt
    public virtual void TakeDamage(int damage, Color damageColor)
    {
        // 弹出伤害值
        int fontSize = damageColor == Color.yellow ? 80 : 64;
        Transform damageNumPoint = transform.Find("DamageNumPoint");
        ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint.position, damage, damageColor, fontSize);

        CurHP.AddFlatModifier(-damage);

        if (CurHP.Value <= 0)
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

        weapon = WeaponFactory.GetWeapon(model, this);
    }

    public virtual void Die()
    {
        if (isDead) return;
        isDead = true;

        // 播放音效
        // 从五个受击音效中随机选取一个
        AudioManager.Instance.PlaySound(AudioType.Hurt, (AudioName)(AudioName.fx_hit_p1 + Random.Range(0, 5)));

        // 生成掉落物
        CreateDropped();

        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        Animator.SetTrigger("Die");
        transform.Find("Collider").gameObject.SetActive(false);
        transform.Find("Trigger").gameObject.SetActive(false);

        // 移除所有buff
        foreach (var buff in buffs.Values)
        {
            buff.EndBuff();
        }
        buffIcon.SetActive(false);

        EventCenter.Instance.NotifyEvent(EventType.OnEnemyDie);
        //CoroutinePool.Instance.StopAllCoroutine(this);
    }

    // 生成掉落物
    // 敌人死亡时调用
    protected virtual void CreateDropped()
    {
        // 生成能量球
        ItemFactory.Instance.CreateDropped(DroppedType.EnergyBall, transform.position, Quaternion.identity);

        // 随机生成金币
        // 随机选择一种金币实例化
        DroppedType[] droppedTypes = new DroppedType[] { DroppedType.CopperCoin, DroppedType.SliverCoin, DroppedType.GoldCoin };
        DroppedType droppedTypeByRandom = droppedTypes[Random.Range(0, droppedTypes.Length)];
        ItemFactory.Instance.CreateDropped(droppedTypeByRandom, transform.position, Quaternion.identity);
    }
}