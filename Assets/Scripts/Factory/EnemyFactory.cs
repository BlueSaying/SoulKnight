using System;
using UnityEngine;

public class EnemyFactory : Singleton<EnemyFactory>
{
    private EnemyFactory() { }

    public Enemy CreateEnemy(EnemyModel enemymodel, Vector2 position, Quaternion quaternion, WeaponModel model)
    {
        EnemyType enemyType = enemymodel.staticAttr.enemyType;
        GameObject obj = InstantiateEnemy(enemyType, position, quaternion);
        Enemy enemy = Activator.CreateInstance(Type.GetType(enemyType.ToString()), new object[] { obj, enemymodel }) as Enemy;

        // 生成敌人的同时生成敌人武器
        enemy.AddWeapon(model);

        UnityTools.GetComponentFromChildren<Symbol>(obj, "Trigger").SetCharacter(enemy);

        return enemy;
    }

    // 实例化一个敌人的游戏物体
    public GameObject InstantiateEnemy(EnemyType type, Vector2 position, Quaternion quaternion, Transform parent = null)
    {
        GameObject enemyPrefab = ResourcesLoader.Instance.LoadEnemy(type.ToString());
        GameObject newEnemy = null;

        if (parent != null)
        {
            newEnemy = UnityEngine.Object.Instantiate(enemyPrefab, position, quaternion, parent);
        }
        else
        {
            newEnemy = UnityEngine.Object.Instantiate(enemyPrefab, position, quaternion);
        }

        newEnemy.name = type.ToString();
        return newEnemy;
    }
}