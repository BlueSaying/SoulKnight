
public class StrangeModel : WeaponModel
{
    public new StrangeStaticAttr staticAttr { get => base.staticAttr as StrangeStaticAttr; protected set => base.staticAttr = value; }

    public StrangeModel(StrangeStaticAttr staticAttr) : base(staticAttr) { }
}