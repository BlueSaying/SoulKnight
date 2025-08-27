public class RifleModel : WeaponModel
{
    public new RifleStaticAttr staticAttr { get => base.staticAttr as RifleStaticAttr; protected set => base.staticAttr = value; }
    public RifleModel(RifleStaticAttr staticAttr) : base(staticAttr) { }
}