using System.Collections.Generic;

public class EnemyModel : AbstractModel
{
    public List<EnemyStaticAttr> datas;

    protected override void OnInit()
    {
        base.OnInit();
        datas = ResourcesLoader.Instance.GetScriptableObject<EnemySO>().attrs;
    }
}
