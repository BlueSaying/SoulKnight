using UnityEngine;

public class Stake : Enemy
{
    public Stake(GameObject obj, EnemyModel model) : base(obj, model) { }

    public override void TakeDamage(int damage, Color damageColor)
    {
        base.TakeDamage(damage, damageColor);
        //Transform damageNumPoint = transform.Find("DamageNumPoint");
        //
        //DamageNum damageNum = ItemFactory.Instance.CreateDamageNum("DamageNum", damageNumPoint, damage, damageColor);

        Animator.SetTrigger("BeAttack");
    }
}