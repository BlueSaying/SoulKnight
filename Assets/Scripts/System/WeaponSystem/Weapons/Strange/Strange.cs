using UnityEngine;

// 杂项整活类武器
public abstract class Strange : Weapon
{
    public new StrangeModel model { get => base.model as StrangeModel; protected set => base.model = value; }

    public Strange(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model) { }
}