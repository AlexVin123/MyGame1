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
    [SerializeField] private float _timeBettwenWave = 10;
    [SerializeField] private DamageableObject _damageableObject;
    [SerializeField] private Bar _progresBar;

    private event Action<float, float> _onChaingeProgresBar;
    [SerializeField] public UnityEvent EndWaveEvent;
    [SerializeField] private UnityEvent _allKilledEvent;

    [SerializeField] private List<Wave> _waves;

    private Timer _timerBettwenSpawn;
    private Timer _timerBettwenWave;

    private int _countAllSpawnEnemy;
    private int _countAllEnemy;
    private int _countKillAll;

    private int _countKillInWave;
    private int _countEnemySpawnInWave;
    private int _countEnemyInWave;

    private int _countEnemySpawnToIndex;
    private int _CountEnemyToIndex;

    private int _currentIndexInWave;
    private int _currentEnemyIndex;
    private int _currentWaveIndex;


    private void OnEnable()
    {
        if (_progresBar != null)
            _onChaingeProgresBar += _progresBar.ChaingeBar;

        _timerBettwenSpawn.OnTimerFinishedEvent += SpawnEnemyInPoints;

    }

    private void OnDisable()
    {
        if (_progresBar != null)
            _onChaingeProgresBar -= _progresBar.ChaingeBar;

        _timerBettwenSpawn.OnTimerFinishedEvent -= SpawnEnemyInPoints;
    }

    public void Start()
    {
        Init();
        _timerBettwenSpawn.OnTimerFinishedEvent += SpawnEnemyInPoints;
        StartWave();
    }

    public void Init()
    {
        _timerBettwenSpawn = new Timer(TimerType.OneSecTick);
        _timerBettwenWave = new Timer(TimerType.OneSecTick);
        InitPools();
        _currentWaveIndex = 0;
        _countAllEnemy = CalculateCountEnemy();
        _countEnemyInWave = _waves[_currentWaveIndex].CountEnemy;
        _currentEnemyIndex = _waves[_currentWaveIndex].GetIndexEnemy(_currentIndexInWave);
        _CountEnemyToIndex = _waves[_currentWaveIndex].CountEnemyToIndex(_currentIndexInWave);
    }

    public void StartWave()
    {
        if (_countEnemyInWave != _countEnemySpawnInWave)
            SpawnEnemyInPoints();
        else
        {
            _currentWaveIndex++;
            _countKillInWave = 0;
            _currentIndexInWave = 0;
            _countEnemySpawnInWave = 0;
            _countEnemySpawnToIndex = 0;
            _countEnemyInWave = _waves[_currentWaveIndex].CountEnemy;
            _CountEnemyToIndex = _waves[_currentWaveIndex].CountEnemyToIndex(_currentIndexInWave);
            _currentEnemyIndex = _waves[_currentWaveIndex].GetIndexEnemy(_currentIndexInWave);
        }

    }

    private void SpawnEnemyInPoints()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            SpawnEnemy(i);

            if (_countEnemyInWave == _countEnemySpawnInWave)
                return;
        }

        _timerBettwenSpawn.Start(_timeBettwenSpawn);
    }

    private void SpawnEnemy(int indexSpawnPoint)
    {
        Enemy enemy = _poolEnemies[_currentEnemyIndex].Spawn(_spawnPoints[indexSpawnPoint].position);
        enemy.OnDyingEvent += OnDyingEnemy;
        _countAllSpawnEnemy++;
        _countEnemySpawnInWave++;
        _countEnemySpawnToIndex++;

        if (_CountEnemyToIndex == _countEnemySpawnToIndex)
        {
            _currentIndexInWave++;
            _countEnemySpawnToIndex = 0;
        }
    }

    private void OnDyingEnemy()
    {
        _countKillAll++;
        _countKillInWave++;
        _onChaingeProgresBar?.Invoke(_countKillAll, _countAllEnemy);

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
