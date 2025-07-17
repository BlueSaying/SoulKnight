using System.Collections.Generic;
using UnityEngine;

internal class EnemyController : AbstractController
{
    private List<Enemy> enemies;
    public EnemyController() { }

    protected override void OnInit()
    {
        base.OnInit();
        enemies = new List<Enemy>();
    }

    protected override void OnAfterRunUpdate()
    {
        base.OnAfterRunUpdate();

        foreach(Enemy enemy in enemies)
        {
            enemy.GameUpdate();
        }
    }

    public void AddEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
    {
        enemies.Add(EnemyFactory.Instance.CreateEnemy(enemyType, position, quaternion));
    }
}