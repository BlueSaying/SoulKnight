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
    public new EnemyStaticAttr staticAttr { get => base.staticAttr as EnemyStaticAttr; set => base.staticAttr = value; }
    public new EnemyDynamicAttr dynamicAttr { get => base.dynamicAttr as EnemyDynamicAttr; set => base.dynamicAttr = value; }

    protected Animator animator;
    //protected PlayerStateMachine stateMachine;

    //protected List<BasePlayerWeapon> weapons;
    //protected BasePlayerWeapon usingWeapon;

    // 当前是否为受击闪烁状态
    private bool isFlashing = false;

    public Enemy(GameObject obj, EnemyStaticAttr staticAttr) : base(obj, staticAttr) { }

    protected override void OnInit()
    {
        base.OnInit();
        animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    protected override void OnCharacterDieStart()
    {
        base.OnCharacterDieStart();
        CoroutinePool.Instance.StopAllCoroutine(this);
    }

    public virtual void TakeDamage(int damage)
    {
        // HACK
        Color color = Color.red;
        Transform damageNumPoint = transform.Find("DamageNumPoint");

        DamageNum damageNum = ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint, damage, color);
        damageNum.ManagedToController();

        animator.SetTrigger("BeAttack");
        if (!isFlashing)
        {
            CoroutinePool.Instance.StartCoroutine(this, BeWhite());
        }

        //dynamicAttr.Hp -= damage;
        Debug.Log(gameObject.ToString() + "受到了" + damage.ToString() + "伤害");
    }

    private IEnumerator BeWhite()
    {
        isFlashing = true;

        SpriteRenderer render = transform.Find("Sprite").GetComponent<SpriteRenderer>();

        render.color = new Color(render.color.r, render.color.g, render.color.b, 0.5f);

        yield return new WaitForSeconds(0.05f);

        render.color = new Color(render.color.r, render.color.g, render.color.b, 1f);

        isFlashing = false;
    }
}