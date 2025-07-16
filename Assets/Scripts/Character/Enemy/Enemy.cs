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

    public virtual void TakeDamage(int damage)
    {
        dynamicAttr.Hp -= damage;
        Debug.Log(dynamicAttr.Hp);
    }
}