using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UIElements;

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

    public EnemyModel GetEnemyModel(EnemyType enemyType)
    {
        return enemyRepository.GetEnemyModel(enemyType);
    }

    // 在场景中添加一个敌人
    public void AddEnemy(EnemyType enemyType, Vector2 position, Quaternion quaternion)
    {
        ItemFactory.Instance.CreateEffect(EffectType.SummonEffect, position, quaternion);

        CoroutinePool.Instance.StartCoroutine(this, SummonEnemy(enemyType, position, quaternion));
    }

    private IEnumerator SummonEnemy(EnemyType enemyType, Vector2 position, Quaternion quaternion)
    {
        yield return new WaitForSeconds(1f);

        enemies.Add(EnemyFactory.Instance.CreateEnemy(enemyRepository.GetEnemyModel(enemyType), position, quaternion));
        ItemFactory.Instance.CreateEffect(EffectType.AppearEffect, position, quaternion);
    }
}