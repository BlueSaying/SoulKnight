
public class PistolModel : WeaponModel
{
    public new PistolStaticAttr staticAttr { get => base.staticAttr as PistolStaticAttr; protected set => base.staticAttr = value; }

    public PistolModel(WeaponStaticAttr staticAttr) : base(staticAttr) { }
}