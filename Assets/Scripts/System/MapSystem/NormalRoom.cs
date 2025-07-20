using System.Collections.Generic;
using UnityEngine;

public class NormalRoom : Room
{
    // 当前剩余敌人数量
    private int curEnemyCount;

    // 总波数
    public int waveCount;

    // 每波敌人数量
    public List<int> enemyCountPerWave;

    public NormalRoom(LevelType levelType, RoomType roomType, Vector2Int roomPos) : base(levelType, roomType, roomPos)
    {
        curEnemyCount = 0;
        waveCount = UnityTools.Instance.GetRandomInt(2, 3);

        for (int i = 0; i < waveCount; i++)
        {
            enemyCountPerWave.Add(UnityTools.Instance.GetRandomInt(5, 10 - i));
        }
    }
}

