using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<PoolEnemy> _poolEnemies;
    [SerializeField] private float _timeBettwenSpawn = 3;
    [SerializeField] private DamageableObject _damageableObject;
    [SerializeField] private List<Wave> _waves;

    private Timer _timerBettwenSpawn;

    private int _countAllSpawnEnemy;
    private int _countAllEnemy;
    private int _countKillAll;

    private int _countKillInWave;
    private int _countEnemySpawnInWave;
    private int _countEnemyInWave;

    private int _countEnemySpawnToIndex;
    private int _CountEnemyToIndex;

    private int _currentIndexEnemyInWave;
    private EnemyType _currentEnemyType;
    private int _currentWaveIndex;

    private Dictionary<EnemyType, PoolEnemy> _enemyPoolDictionary;

    public UnityAction<int> ChaigedWave;
    public UnityAction<float,float> ChaigedWaveProgress;
    public UnityAction EndWave;
    public UnityAction EndSpawn;

    public int CountWave => _waves.Count;
    private void OnEnable()
    {



    }

    private void OnDisable()
    {
        //_timerBettwenSpawn.Stop();

        _timerBettwenSpawn.OnTimerFinishedEvent -= SpawnEnemyInPoints;
        Unsubscribe();
    }

    public void Init()
    {
        _enemyPoolDictionary = new Dictionary<EnemyType, PoolEnemy>();

        foreach (var item in _poolEnemies)
        {
            _enemyPoolDictionary.Add(item.EnemyIndex, item);
        }

        _timerBettwenSpawn = new Timer(TypeTimer.OneSecTick);
        InitPools();
        _currentWaveIndex = 0;
        ChaigedWave?.Invoke(_currentWaveIndex);
        _countAllEnemy = CalculateCountEnemy();
        _countEnemyInWave = _waves[_currentWaveIndex].CountEnemy;
        _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
        _CountEnemyToIndex = _waves[_currentWaveIndex].CountEnemyToType(_currentIndexEnemyInWave);

        _timerBettwenSpawn.OnTimerFinishedEvent += SpawnEnemyInPoints;
        Subscribe();


    }

    private void Subscribe()
    {
        foreach (var item in _poolEnemies)
        {
            Enemy[] enemies = item.GetAllEnemy();

            foreach (Enemy enemy in enemies)
            {
                enemy.Dying += OnDyingEnemy;
            }
        }
    }

    private void Unsubscribe()
    {
        foreach (var item in _poolEnemies)
        {
            Enemy[] enemies = item.GetAllEnemy();

            foreach (Enemy enemy in enemies)
            {
                enemy.Dying -= OnDyingEnemy;
            }
        }
    }

    public void SpawnEnemyInPoints()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if(_countEnemyInWave != _countEnemySpawnInWave)
            {
            SpawnEnemy(i);

                if (_CountEnemyToIndex == _countEnemySpawnToIndex && _currentIndexEnemyInWave != _waves[_currentWaveIndex].CountEnemyType() - 1)
                {
                    _currentIndexEnemyInWave++;
                    _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
                    _countEnemySpawnToIndex = 0;
                    _CountEnemyToIndex = _waves[_currentWaveIndex].CountEnemyToType(_currentIndexEnemyInWave);
                }
            }
        }

        if (_countEnemySpawnInWave != _countEnemyInWave)
        {
            _timerBettwenSpawn.Start(_timeBettwenSpawn);
        }
    }

    private void SpawnEnemy(int indexSpawnPoint)
    {
        _enemyPoolDictionary[_currentEnemyType].Spawn(_spawnPoints[indexSpawnPoint].position);
        _countAllSpawnEnemy++;
        _countEnemySpawnInWave++;
        _countEnemySpawnToIndex++;
    }

    private void OnDyingEnemy()
    {
        _countKillAll++;
        _countKillInWave++;
        ChaigedWaveProgress?.Invoke(_countKillInWave, _countEnemyInWave);

        if (_countKillInWave == _countEnemyInWave && _currentWaveIndex != _waves.Count - 1)
        {
             EndWave?.Invoke();
            _currentWaveIndex++;
            ChaigedWave?.Invoke(_currentWaveIndex);
            _countKillInWave = 0;
            _currentIndexEnemyInWave = 0;
            _countEnemySpawnInWave = 0;
            _countEnemySpawnToIndex = 0;
            _countEnemyInWave = _waves[_currentWaveIndex].CountEnemy;
            ChaigedWaveProgress?.Invoke(_countKillInWave, _countEnemyInWave);
            _CountEnemyToIndex = _waves[_currentWaveIndex].CountEnemyToType(_currentIndexEnemyInWave);
            _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
        }

        if(_countAllEnemy == _countKillAll)
            EndSpawn?.Invoke();
    }

    private void InitPools()
    {
        foreach (var pool in _poolEnemies)
        {
            pool.Init(transform, _damageableObject);
        }
    }

    private int CalculateCountEnemy()
    {
        int count = 0;

        foreach (var wave in _waves)
        {
            count += wave.CountEnemy;
        }

        return count;
    }



}
