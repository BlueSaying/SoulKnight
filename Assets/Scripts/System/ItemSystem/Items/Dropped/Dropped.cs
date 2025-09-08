using UnityEngine;

/// <summary>
/// 掉落物基类
/// </summary>
public abstract class Dropped : Item
{
    protected Player player;
    protected abstract float PickUpDistance { get; }

    protected TriggerDetector triggerDetector;
    protected Rigidbody2D rb;

    public Animator animator { get; protected set; }

    private bool isFollowingPlayer;
    public bool IsFollowingPlayer
    {
        get
        {
            return isFollowingPlayer;
        }
        protected set
        {
            isFollowingPlayer = value;
            if (animator != null) animator.SetBool("isFollowingPlayer", isFollowingPlayer);
        }
    }

    public Dropped(GameObject gameObject) : base(gameObject) { }

    protected override void OnInit()
    {
        base.OnInit();
        rb = gameObject.GetComponent<Rigidbody2D>();

        try
        {
            triggerDetector = gameObject.GetComponent<TriggerDetector>();
            triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
            {
                OnHitPlayer(player);
            });
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的TriggerDetector组件,请检查是否已经添加");
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
        animator = gameObject.GetComponent<Animator>();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        if (IsFollowingPlayer)
        {
            const float FollowingSpeed = 20f;
            Vector2 dir = (player.transform.position - gameObject.transform.position).normalized;
            MoveManager.Move(rb, dir * FollowingSpeed);
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (player != null && DistanceToPlayer() < PickUpDistance)
        {
            IsFollowingPlayer = true;
        }
        else
        {
            IsFollowingPlayer = false;
        }
    }

    // 计算当前物品到玩家的距离
    protected float DistanceToPlayer()
    {
        return Vector2.Distance(player.transform.position, gameObject.transform.position);
    }

    public virtual void Reset(Vector3 position, Quaternion quaternion)
    {
        base.Reset();
        this.position = position;
        this.rotation = quaternion;
    }

    protected virtual void OnHitPlayer(Player player)
    {
        Remove();
    }
}