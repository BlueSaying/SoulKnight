using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : BaseSystem
{
    private EnemyRepository enemyRepository;

    public List<Enemy> enemies { get; private set; }
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

    protected override void OnExit()
    {
        base.OnExit();

        enemies.Clear();
    }

    public EnemyModel GetEnemyModel(EnemyType enemyType)
    {
        return enemyRepository.GetEnemyModel(enemyType);
    }

    // 在场景中添加一个敌人
    public void AddEnemy(EnemyType enemyType, Vector2 position, Quaternion quaternion, WeaponModel model)
    {
        ItemFactory.Instance.CreateEffect(EffectType.SummonEffect, position, quaternion);

        UnityTools.Instance.WaitThenCallFun(this, 1f, () =>
        {
            ItemFactory.Instance.CreateEffect(EffectType.AppearEffect, position, quaternion);

            UnityTools.Instance.WaitThenCallFun(this, 0.416667f, () =>
            {
                enemies.Add(EnemyFactory.Instance.CreateEnemy(enemyRepository.GetEnemyModel(enemyType), position, quaternion, model));
            });
        });
    }
}