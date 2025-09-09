using UnityEngine;

// 杂项整活类武器
public abstract class Strange : Weapon
{
    public new StrangeModel model { get => base.model as StrangeModel; protected set => base.model = value; }

    public Strange(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }

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
}