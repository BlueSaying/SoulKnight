using System.Collections;
using UnityEngine;

public abstract class Melee : Weapon
{
    public new MeleeModel model { get => base.model as MeleeModel; protected set => base.model = value; }

    protected TriggerDetector triggerDetector;

    protected Melee(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

    protected override (int damage, bool isCritical) CalcDamageInfo()
    {
        int damageOutput = Damage;
        bool isCriticalOutput = false;
        int criticalRate = CriticalRate + (owner is Player player ? player.critical : 0);

        if (Random.Range(0f, 100f) < criticalRate)
        {
            damageOutput *= 2;
            isCriticalOutput = true;
        }

        return (damageOutput, isCriticalOutput);
    }

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

        if (owner is Enemy)
        {
            triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
            {
                OnHitPlayer(obj.GetComponent<Symbol>().character as Player);
            });
        }
        else if (owner is Player)
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

        AudioManager.Instance.PlaySound(AudioType.Sword, Random.Range(0, 2) > 0 ? AudioName.fx_sword1 : AudioName.fx_sword2);

        // 产生位移
        if (owner is Player)
        {
            float angle = rotation.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (rotation.eulerAngles.y != 0) dir.x *= -1;

            CoroutinePool.Instance.StartCoroutine(this, AttackMove(dir));
        }
    }

    protected virtual void OnHitEnemy(Enemy enemy) { }
    protected virtual void OnHitPlayer(Player player) { }

    private IEnumerator AttackMove(Vector2 dir)
    {
        float timer = 0f;
        float time = 0.15f;

        yield return new WaitForSeconds(2.0f / 12.0f);

        while (true)
        {
            timer += Time.fixedDeltaTime;
            if (timer > time) break;

            MoveManager.Move(owner.rb, dir * 40f, 400f, 50f);
            yield return null;
        }
    }
}