
    public class StaffModel:WeaponModel
    {
    public new StaffStaticAttr staticAttr { get => base.staticAttr as StaffStaticAttr; protected set => base.staticAttr = value; }
    public StaffModel(StaffStaticAttr staticAttr) : base(staticAttr) { }
}