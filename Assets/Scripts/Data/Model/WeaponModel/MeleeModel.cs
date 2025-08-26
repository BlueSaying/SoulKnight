public class MeleeModel : WeaponModel
{
    public new MeleeStaticAttr staticAttr { get => base.staticAttr as MeleeStaticAttr; protected set => base.staticAttr = value; }

    public MeleeModel(WeaponStaticAttr staticAttr) : base(staticAttr) { }
}