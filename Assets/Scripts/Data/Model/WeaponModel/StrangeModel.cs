
public class StrangeModel : WeaponModel
{
    public new StrangeStaticAttr staticAttr { get => base.staticAttr as StrangeStaticAttr; protected set => base.staticAttr = value; }

    public StrangeModel(WeaponStaticAttr staticAttr) : base(staticAttr) { }
}