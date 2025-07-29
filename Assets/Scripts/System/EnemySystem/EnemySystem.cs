using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : BaseSystem
{
    private EnemyRepository enemyRepository;

    private List<Enemy> enemies;
    public EnemySystem() { }

    protected override void OnInit()
    {
        base.OnInit();

        enemies = new List<Enemy>();
        enemyRepository = new EnemyRepository();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        foreach (Enemy enemy in enemies)
        {
            enemy.GameUpdate();
        }
    }

    public void AddEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
    {
        enemies.Add(EnemyFactory.Instance.CreateEnemy(enemyRepository.GetEnemyModel(enemyType), position, quaternion));
    }
}