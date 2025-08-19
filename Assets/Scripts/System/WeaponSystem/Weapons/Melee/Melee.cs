
using UnityEngine;

public abstract class Melee : Weapon
{
    protected TriggerDetector triggerDetector;

    protected Melee(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override void OnInit()
    {
        base.OnInit();
        try
        {
            triggerDetector = UnityTools.Instance.GetComponentFromChildren<TriggerDetector>(gameObject, "MeleeTrigger");
        }
        catch (System.Exception)
        {
            throw new System.Exception("无法获取" + gameObject.name + "的TriggerDetector组件,请检查是否已经添加");
        }

        if (owner.GetType().IsSubclassOf(typeof(Enemy)))
        {
            triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
            {
                OnHitPlayer(obj.GetComponent<Symbol>().character as Player);
            });
        }
        else if (owner.GetType().IsSubclassOf(typeof(Player)))
        {
            triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Enemy", (obj) =>
            {
                OnHitEnemy(obj.GetComponent<Symbol>().character as Enemy);
            });
        }
    }

    protected override void OnFire()
    {
        base.OnFire();
        if (TestManager.Instance.isUnlockWeapon) animator.speed = 5f;
        else animator.speed = 1f;
        animator.SetTrigger("Attack");
        AudioManager.Instance.PlaySound(AudioType.sword, Random.Range(0, 2) > 0 ? AudioName.fx_sword1 : AudioName.fx_sword2);

        //owner.rb.AddForce(Vector2.right * 100);
    }

    protected virtual void OnHitEnemy(Enemy enemy) { }
    protected virtual void OnHitPlayer(Player player) { }
}