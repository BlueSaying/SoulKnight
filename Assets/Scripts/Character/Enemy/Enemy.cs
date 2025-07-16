using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public new EnemyStaticAttr staticAttr { get => base.staticAttr as EnemyStaticAttr; set => base.staticAttr = value; }
    public new EnemyDynamicAttr dynamicAttr { get => base.dynamicAttr as EnemyDynamicAttr; set => base.dynamicAttr = value; }

    protected Animator animator;
    //protected PlayerStateMachine stateMachine;

    //protected List<BasePlayerWeapon> weapons;
    //protected BasePlayerWeapon usingWeapon;

    public Enemy(GameObject obj) : base(obj) { }

}