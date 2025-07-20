using System.Collections.Generic;

public class PlayerModel : AbstractModel
{
    public List<PlayerStaticAttr> datas;

    protected override void OnInit()
    {
        base.OnInit();
        datas = ResourcesLoader.Instance.GetScriptableObject<PlayerSO>().attrs;
    }   
}