using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBettwenSpawn;
    [SerializeField] private DamageableObject _topTarget;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<PoolEnemy> _poolEnemies;
    [SerializeField] private List<Wave> _waves;

    private WaitForSeconds _timer;
    private SpawnerCounter _counter;

    private int _currentIndexEnemyInWave;
    private int _currentWaveIndex;
    private EnemyType _currentEnemyType;

    private Dictionary<EnemyType, PoolEnemy> _enemyPoolDictionary;
    public int CountWave => _waves.Count;

    public event UnityAction<int> ChaigedWave;
    public event UnityAction<float, float> ChaigedWaveProgress;
    public event UnityAction EndWave;
    public event UnityAction EndSpawn;

    private void OnDisable()
    {
        Unsubscribe();
    }

    public void Init()
    {
        _enemyPoolDictionary = new Dictionary<EnemyType, PoolEnemy>();
        _timer = new WaitForSeconds(_timeBettwenSpawn);

        foreach (var item in _poolEnemies)
        {
            _enemyPoolDictionary.Add(item.EnemyIndex, item);
        }

        InitPools();
        _currentWaveIndex = 0;
        ChaigedWave?.Invoke(_currentWaveIndex);
        _counter = new SpawnerCounter(CalculateCountEnemy(), _waves[_currentWaveIndex]);
        Subscribe();
    }

    public void OnPanelClouse()
    {
        ChaigedWave?.Invoke(_currentWaveIndex);
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        if (_counter.TryAllEnemyInWaveKill())
        {
            _currentWaveIndex++;
            _counter.RecalculationNewWave(_waves[_currentWaveIndex]);
            EndWave?.Invoke();
            StopCoroutine(StartSpawn());
        }

        _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);

        while (_counter.TryAllEnemyInWaveSpawn() == false)
        {
            SpawnEnemyInPoints();
            yield return _timer;
        }
    }

    private void Subscribe()
    {
        foreach (var poolEnemy in _poolEnemies)
        {
            Enemy[] enemies = poolEnemy.GetAllEnemy();

            foreach (Enemy enemy in enemies)
                enemy.Dying += OnDyingEnemy;
        }
    }

    private void Unsubscribe()
    {
        foreach (var poolEnemy in _poolEnemies)
        {
            Enemy[] enemies = poolEnemy.GetAllEnemy();

            foreach (Enemy enemy in enemies)
                enemy.Dying -= OnDyingEnemy;
        }
    }

    private void SpawnEnemyInPoints()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_counter.TryAllEnemyInWaveSpawn() == false)
            {
                SpawnEnemy(i);

                if (_counter.TryAllEnemyToTypeSpawn() && _counter.TryAllEnemyInWaveSpawn() == false)
                {
                    _currentIndexEnemyInWave++;
                    _counter.RecalculationNewEnemyType(_waves[_currentWaveIndex], _currentIndexEnemyInWave);
                    _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
                }
            }
        }
    }

    private void SpawnEnemy(int indexSpawnPoint)
    {
        _enemyPoolDictionary[_currentEnemyType].Spawn(_spawnPoints[indexSpawnPoint].position, _topTarget);
        _counter.OnSpawnEnemy();
    }

    private void OnDyingEnemy()
    {
        _counter.OnKillEnemy();
        ChaigedWaveProgress?.Invoke(_counter.CountEnemyKillInWave, _counter.CountEnemyInWave);

        if (_counter.TryAllEnemyKill())
        {
            EndSpawn?.Invoke();
            return;
        }

        if (_counter.TryAllEnemyInWaveKill())
        {
            EndWave?.Invoke();
            _currentWaveIndex++;
            _counter.RecalculationNewWave(_waves[_currentWaveIndex]);
            ChaigedWaveProgress?.Invoke(_counter.CountEnemyKillInWave, _counter.CountEnemyInWave);
        }
    }

    private void InitPools()
    {
        foreach (var pool in _poolEnemies)
            pool.Init(transform, _topTarget);
    }

    private int CalculateCountEnemy()
    {
        int count = 0;

        foreach (var wave in _waves)
            count += wave.CountEnemy;

        return count;
    }
}
