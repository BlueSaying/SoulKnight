using System.Collections.Generic;
using UnityEngine;

public class NormalRoom : Room
{
    private bool hasBattled;

    // 当前剩余敌人数量
    private int curEnemyCount;

    // 当前波数
    private int curWaveCount;

    // 总波数
    public int waveCount;

    // 每波敌人数量
    public List<int> enemyCountPerWave;

    public NormalRoom(LevelType levelType, RoomType roomType, Vector2Int roomPos, GameObject gameObject) : base(levelType, roomType, roomPos, gameObject)
    {
        waveCount = UnityTools.Instance.GetRandomInt(2, 3);
        enemyCountPerWave = new List<int>();
        for (int i = 0; i < waveCount; i++)
        {
            enemyCountPerWave.Add(UnityTools.Instance.GetRandomInt(5, 10 - i));
        }
        curEnemyCount = 0;
        curWaveCount = 0;

        gameObject.transform.Find("EnterRoomTrigger").GetComponent<TriggerDetector>().
            AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", OnPlayerEnter);
    }

    public override void OnPlayerEnter(GameObject obj)
    {
        base.OnPlayerEnter(obj);

        if (!hasBattled)
        {
            hasBattled = true;

            // 当玩家进入普通房间时房门关闭
            CloseDoor();
            SummonEnemy();

            EventCenter.Instance.RegisterEvent(EventType.OnEnemyDie, OnEnemyDie);
            EventCenter.Instance.RegisterEvent(EventType.OnBattleFinish, OnBattleFinish);
        }
    }

    public void SummonEnemy()
    {
        for (int i = 0; i < enemyCountPerWave[curWaveCount]; i++)
        {
            EnemyType enemyType = EnemyType.GoblinGuard;  // HACK
            Vector2 pos = roomPos * RoomCreator.UnitSize + new Vector2(UnityTools.Instance.GetRandomFloat(-5, 5), UnityTools.Instance.GetRandomFloat(-5, 5));
            SystemRepository.Instance.GetSystem<EnemySystem>().AddEnemy(enemyType, pos, Quaternion.identity);
        }
        curEnemyCount = enemyCountPerWave[curWaveCount];
    }

    #region 事件集
    public void OnEnemyDie()
    {
        curEnemyCount--;
        if (curEnemyCount <= 0)
        {
            curWaveCount++;
            if (curWaveCount >= waveCount)
            {
                EventCenter.Instance.NotifyEvent(EventType.OnBattleFinish);
            }
            else
            {
                SummonEnemy();
            }
        }
        Debug.Log("已完成波数:" + curWaveCount + "/" + waveCount + " 当前剩余敌人数:" + curEnemyCount);
    }

    public void OnBattleFinish()
    {
        OpenDoor();
        EventCenter.Instance.RemoveEvent(EventType.OnEnemyDie, OnEnemyDie);
        //EventCenter.Instance.RemoveEvent(EventType.OnBattleFinish, OnBattleFinish);
    }
    #endregion
}