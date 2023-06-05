using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField]private EnemysInWave[] enemiesInWave;

    public int CountEnemy => CalculateCount();

    public EnemyType GetEnemyType(int index)
    {
        return enemiesInWave[index].EnemyType;
    }

    public int CountEnemyToType(int index)
    {
        return enemiesInWave[index].Count;
    }

    public int CountEnemyType()
    {
        return enemiesInWave.Length;
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
