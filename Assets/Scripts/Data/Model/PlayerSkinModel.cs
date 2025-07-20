using System.Collections.Generic;

public class PlayerSkinModel : AbstractModel
{
    public List<PlayerSkinStaticAttr> datas;

    protected override void OnInit()
    {
        base.OnInit();
        datas = ResourcesLoader.Instance.GetScriptableObject<PlayerSkinSO>().attrs;
    }
}