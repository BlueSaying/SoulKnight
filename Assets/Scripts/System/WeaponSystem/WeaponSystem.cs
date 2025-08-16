
public class WeaponSystem : BaseSystem
{
    // 系统持有的武器库
    private WeaponRepository weaponRepository;

    public WeaponSystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        weaponRepository = new WeaponRepository();
    }

    public WeaponModel GetWeaponModel(WeaponType playerWeaponType)
    {
        return weaponRepository.GetWeaponModel(playerWeaponType);
    }
}