using Unity.VisualScripting;
using UnityEngine;

public class EnemyFactory : Singleton<EnemyFactory>
{
    private EnemyFactory() { }

    public Enemy CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
    {
        GameObject newEnemy = InstantiateEnemy(enemyType, position, quaternion);
        EnemyStaticAttr staticAttr = EnemyCommand.Instance.GetEnemyStaticAttr(enemyType);
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.Stake:
                enemy = new Stake(newEnemy, new EnemyStaticAttr()); // HACK
                break;
        }

        UnityTools.Instance.GetComponentFromChildren<Symbol>(newEnemy, "BulletCheckBox").SetCharacter(enemy);

        return enemy;
    }

    // 实例化一个敌人的游戏物体
    public GameObject InstantiateEnemy(EnemyType type, Vector3 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject enemyPrefab = ResourcesFactory.Instance.GetEnemy(type.ToString());
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