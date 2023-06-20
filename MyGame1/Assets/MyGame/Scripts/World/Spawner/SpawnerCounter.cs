using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCounter
{
    private int _countAllEnemy;
    private int _countAllEnemyKill;

    private int _countEnemyKillInWave;
    private int _countEnemySpawnInWave;
    private int _countEnemyInWave;

    private int _countEnemySpawnToType;
    private int _countEnemyToType;

    public int CountEnemyInWave => _countEnemyInWave;
    public int CountEnemyKillInWave => _countEnemyKillInWave;

    public SpawnerCounter(int countAllEnemy, Wave startWave)
    {
        _countAllEnemy = countAllEnemy;
        _countAllEnemyKill = 0;
        RecalculationNewWave(startWave);
        RecalculationNewEnemyType(startWave, 0);
    }

    public void RecalculationNewWave(Wave value)
    {
        _countEnemyInWave = value.CountEnemy;
        _countEnemyKillInWave = 0;
        _countEnemySpawnInWave = 0;
        RecalculationNewEnemyType(value, 0);
    }

    public void RecalculationNewEnemyType(Wave currentWave, int indexEnemyInWave)
    {
        _countEnemyToType = currentWave.CountEnemyToType(0);
        _countEnemySpawnToType = 0;
    }

    public void OnSpawnEnemy()
    {
        _countEnemySpawnInWave++;
        _countEnemySpawnToType++;
    }

    public void OnKillEnemy()
    {
        _countAllEnemyKill++;
        _countEnemyKillInWave++;
    }

    public bool TryAllEnemyKill() => _countAllEnemyKill == _countAllEnemy;

    public bool TryAllEnemyInWaveKill() => _countEnemyInWave == _countEnemyKillInWave;

    public bool TryAllEnemyInWaveSpawn() => _countEnemyInWave == _countEnemySpawnInWave;

    public bool TryAllEnemyToTypeSpawn() => _countEnemyToType == _countEnemySpawnToType;
}
