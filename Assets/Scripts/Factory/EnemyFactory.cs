using Unity.VisualScripting;
using UnityEngine;

public class EnemyFactory : Singleton<EnemyFactory>
{
    private EnemyFactory() { }

    public Enemy CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetEnemy(enemyType.ToString()), position, quaternion);
        EnemyStaticAttr staticAttr = EnemyCommand.Instance.GetEnemyStaticAttr(enemyType);
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.Stake:
                enemy = new Stake(obj, new EnemyStaticAttr());
                break;
        }

        if (!UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox"))
        {
            UnityTools.Instance.GetTransformFromChildren(obj, "BulletCheckBox").AddComponent<Symbol>();
        }
        UnityTools.Instance.GetComponentFromChildren<Symbol>(obj, "BulletCheckBox").SetCharacter(enemy);

        return enemy;
    }
}