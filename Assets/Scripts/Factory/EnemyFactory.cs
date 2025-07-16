using UnityEngine;

public enum EnemyType
{
    Stake,
}

public class EnemyFactory : Singleton<EnemyFactory>
{
    private EnemyFactory() { }

    public Enemy CreateEnemy(EnemyType enemyType)
    {
        GameObject obj = Object.Instantiate(ResourcesFactory.Instance.GetEnemy(enemyType.ToString()));
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.Stake:
                enemy = new Stake(obj);
                break;
        }

        return enemy;
    }
}