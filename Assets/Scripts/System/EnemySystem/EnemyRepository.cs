using System.Collections.Generic;

public class EnemyRepository
{
    // 储存所有角色的数据
    private List<EnemyModel> models;

    public EnemyRepository()
    {
        List<EnemyStaticAttr> enemyStaticData = SOLoader.Instance.LoadScriptableObject<EnemySO>().attrs;

        models = new List<EnemyModel>();
        for (int i = 0; i < enemyStaticData.Count; i++)
        {
            models.Add(new EnemyModel(enemyStaticData[i], new EnemyDynamicAttr()));
        }
    }

    public EnemyModel GetEnemyModel(EnemyType enemyType)
    {
        foreach (var model in models)
        {
            if (model.staticAttr.enemyType == enemyType)
            {
                return model;
            }
        }

        return default;
    }
}
