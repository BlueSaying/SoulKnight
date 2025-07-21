using UnityEngine;

public class EnemyFactory : Singleton<EnemyFactory>
{
    private EnemyFactory() { }

    public Enemy CreateEnemy(EnemyModel enemymodel, Vector3 position, Quaternion quaternion)
    {
        EnemyType enemyType = enemymodel.staticAttr.enemyType;
        GameObject obj = InstantiateEnemy(enemyType, position, quaternion);
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.Stake:
                enemy = new Stake(obj, enemymodel);
                break;
        }

        UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").SetCharacter(enemy);

        return enemy;
    }

    // 实例化一个敌人的游戏物体
    public GameObject InstantiateEnemy(EnemyType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject enemyPrefab = ResourcesLoader.Instance.LoadEnemy(type.ToString());
        GameObject newEnemy = null;

        if (parent != null)
        {
            newEnemy = Object.Instantiate(enemyPrefab, position, quaternion, parent);
        }
        else
        {
            newEnemy = Object.Instantiate(enemyPrefab, position, quaternion);
        }

        newEnemy.name = type.ToString();
        return newEnemy;
    }
}