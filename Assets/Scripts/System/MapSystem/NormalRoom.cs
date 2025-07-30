using System.Collections.Generic;
using UnityEngine;

public class NormalRoom : Room
{
    // 当前剩余敌人数量
    private int curEnemyCount;

    // 当前波数
    private int curWaveCount;

    // 总波数
    public int waveCount;

    // 每波敌人数量
    public List<int> enemyCountPerWave;

    public NormalRoom(LevelType levelType, RoomType roomType, Vector2Int roomPos,GameObject gameObject) : base(levelType, roomType, roomPos,gameObject)
    {
        curEnemyCount = 0;
        curWaveCount = 0;
        waveCount = UnityTools.Instance.GetRandomInt(2, 3);

        enemyCountPerWave = new List<int>();
        for (int i = 0; i < waveCount; i++)
        {
            enemyCountPerWave.Add(UnityTools.Instance.GetRandomInt(5, 10 - i));
        }

        gameObject.transform.Find("EnterRoomTrigger").GetComponent<TriggerDetector>().
            AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", OnPlayerEnter);
    }

    public override void OnPlayerEnter(GameObject obj)
    {
        base.OnPlayerEnter(obj);
        Debug.Log("Enter");

        // 当玩家进入普通房间时房门关闭
        CloseDoor();
    }
}