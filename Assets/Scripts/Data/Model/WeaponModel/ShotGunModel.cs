public class ShotGunModel:WeaponModel
{
    public new ShotGunStaticAttr staticAttr { get => base.staticAttr as ShotGunStaticAttr; protected set => base.staticAttr = value; }
    public ShotGunModel(ShotGunStaticAttr staticAttr) : base(staticAttr) { }
}