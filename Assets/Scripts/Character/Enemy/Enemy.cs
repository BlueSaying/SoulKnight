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

    public Enemy(GameObject obj, EnemyStaticAttr staticAttr) : base(obj, staticAttr) { }

    protected override void OnInit()
    {
        base.OnInit();
        animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    public virtual void TakeDamage(int damage)
    {
        // HACK
        Color color = Color.red;
        Transform damageNumPoint = transform.Find("DamageNumPoint");

        DamageNum damageNum = ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint, damage, color);
        damageNum.ManagedToController();

        animator.SetTrigger("BeAttack");

        //dynamicAttr.Hp -= damage;
        Debug.Log(gameObject.ToString() + "受到了" + damage.ToString() + "伤害");
    }
}