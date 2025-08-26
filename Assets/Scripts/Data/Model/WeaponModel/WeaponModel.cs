public class WeaponModel : AbstractModel
{
    public WeaponStaticAttr staticAttr { get;protected set; }

    public WeaponModel(WeaponStaticAttr staticAttr)
    {
        this.staticAttr = staticAttr;
    }
}