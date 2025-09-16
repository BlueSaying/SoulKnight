public class RocketLauncherModel : WeaponModel
{
    public new RocketLauncherStaticAttr staticAttr { get => base.staticAttr as RocketLauncherStaticAttr; protected set => base.staticAttr = value; }
    public RocketLauncherModel(RocketLauncherStaticAttr staticAttr) : base(staticAttr) { }
}