
public class PlayerWeaponModel : WeaponModel
{
    public new PlayerWeaponStaticAttr staticAttr { get => base.staticAttr as PlayerWeaponStaticAttr; set => base.staticAttr = value; }

    public PlayerWeaponModel(PlayerWeaponStaticAttr staticAttr) : base(staticAttr) { }
}
