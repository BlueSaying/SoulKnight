
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

    public WeaponModel GetWeaponModel(WeaponCategory weaponCategory, WeaponType WeaponType)
    {
        return weaponRepository.GetWeaponModel(weaponCategory, WeaponType);
    }

    public WeaponModel GetWeaponModel(WeaponType WeaponType)
    {
        return weaponRepository.GetWeaponModel(WeaponType);
    }
}