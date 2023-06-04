using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField]private List<EnemysInWave> enemiesInWave;

    public int CountEnemy => CalculateCount();

    public int GetIndexEnemy(int index)
    {
        return enemiesInWave[index].Index;
    }

    public int CountEnemyToIndex(int index)
    {
        return enemiesInWave[index].Count;
    }

    private int CalculateCount()
    {
        int count = 0;

        foreach (var enemy in enemiesInWave)
        {
            count += enemy.Count;
        }

        return count;
    }

}
