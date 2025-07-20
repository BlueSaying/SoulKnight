using System.Collections.Generic;

public class WeaponModel : AbstractModel
{
    public List<PlayerWeaponStaticAttr> datas;

    protected override void OnInit()
    {
        base.OnInit();
        datas = ResourcesLoader.Instance.GetScriptableObject<PlayerWeaponSO>().attrs;
    }
}