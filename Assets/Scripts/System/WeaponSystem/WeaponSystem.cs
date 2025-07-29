
public class WeaponSystem : BaseSystem
{
    // 系统持有的武器库
    private PlayerWeaponRepository playerWeaponRepository;
    //enemyWeaponRepository

    public WeaponSystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        playerWeaponRepository = new PlayerWeaponRepository();
    }

    public PlayerWeaponModel GetPlayerWeaponModel(PlayerWeaponType playerWeaponType)
    {
        return playerWeaponRepository.GetPlayerWeaponModel(playerWeaponType);
    }
}
