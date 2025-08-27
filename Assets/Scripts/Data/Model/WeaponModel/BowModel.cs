public class BowModel : WeaponModel
{
    public new BowStaticAttr staticAttr { get => base.staticAttr as BowStaticAttr; protected set => base.staticAttr = value; }

    public BowModel(BowStaticAttr staticAttr) : base(staticAttr) { }
}