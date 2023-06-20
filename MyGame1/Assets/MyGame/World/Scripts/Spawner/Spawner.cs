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
    [SerializeField] private Bar _healtBarEndEnemy;

    private WaitForSeconds _timer;
    private Enemy _endSpawnEnemy;

    private int _countAllEnemy;
    private int _countAllEnemySpawn;
    private int _countAllEnemyKill;

    private int _countEnemyKillInWave;
    private int _countEnemySpawnInWave;
    private int _countEnemyInWave;

    private int _countEnemySpawnToType;
    private int _CountEnemyToType;

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
        _countAllEnemy = CalculateCountEnemy();
        _countEnemyInWave = _waves[_currentWaveIndex].CountEnemy;
        _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
        _CountEnemyToType = _waves[_currentWaveIndex].CountEnemyToType(_currentIndexEnemyInWave);
        Subscribe();
    }

    public void OnPanelClouse()
    {
        StartCoroutine(StartSpawm());
    }

    private IEnumerator StartSpawm()
    {
        if (_countAllEnemy == _countAllEnemySpawn)
            StopCoroutine(StartSpawm());

        if (_countEnemyInWave == _countEnemyKillInWave)
            NextWave();


        while (_countEnemyInWave != _countEnemySpawnInWave)
        {
            SpawnEnemyInPoints();
            yield return _timer;
        }

        if (_currentWaveIndex == _waves.Count)
        {
            EndSpawn.Invoke();
            StopCoroutine(StartSpawm());
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

    private void NextWave()
    {
        EndWave?.Invoke();

        if (_currentWaveIndex != _waves.Count - 1)
            _currentWaveIndex++;

        _countEnemyKillInWave = 0;
        _currentIndexEnemyInWave = 0;
        _countEnemySpawnInWave = 0;
        _countEnemySpawnToType = 0;
        _countEnemyInWave = _waves[_currentWaveIndex].CountEnemy;
        _CountEnemyToType = _waves[_currentWaveIndex].CountEnemyToType(_currentIndexEnemyInWave);
        _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
        ChaigedWave?.Invoke(_currentWaveIndex);
        ChaigedWaveProgress?.Invoke(_countEnemyKillInWave, _countEnemyInWave);
    }

    private void Unsubscribe()
    {
        foreach (var poolEnemy in _poolEnemies)
        {
            Enemy[] enemies = poolEnemy.GetAllEnemy();

            foreach (Enemy enemy in enemies)
                enemy.Dying -= OnDyingEnemy;
        }
        if (_endSpawnEnemy != null)
            _endSpawnEnemy.ChaigedHealth -= _healtBarEndEnemy.ChaingeBar;
    }

    private void NextEnemyType()
    {
        _currentIndexEnemyInWave++;
        _currentEnemyType = _waves[_currentWaveIndex].GetEnemyType(_currentIndexEnemyInWave);
        _countEnemySpawnToType = 0;
        _CountEnemyToType = _waves[_currentWaveIndex].CountEnemyToType(_currentIndexEnemyInWave);
    }

    private void SpawnEnemyInPoints()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_countEnemyInWave != _countEnemySpawnInWave)
            {
                SpawnEnemy(i);

                if (_CountEnemyToType == _countEnemySpawnToType && _currentIndexEnemyInWave != _waves[_currentWaveIndex].CountEnemyType() - 1)
                    NextEnemyType();
            }
        }
    }

    private void SpawnEnemy(int indexSpawnPoint)
    {
        _endSpawnEnemy = _enemyPoolDictionary[_currentEnemyType].Spawn(_spawnPoints[indexSpawnPoint].position);

        if (_healtBarEndEnemy != null)
            _endSpawnEnemy.ChaigedHealth = _healtBarEndEnemy.ChaingeBar;

        _endSpawnEnemy.Reset(_topTarget);
        _countAllEnemySpawn++;
        _countEnemySpawnInWave++;
        _countEnemySpawnToType++;
    }

    private void OnDyingEnemy()
    {
        _countAllEnemyKill++;
        _countEnemyKillInWave++;
        ChaigedWaveProgress?.Invoke(_countEnemyKillInWave, _countEnemyInWave);

        if (_countEnemyKillInWave == _countEnemyInWave && _currentWaveIndex != _waves.Count - 1)
            NextWave();

        if (_countAllEnemy == _countAllEnemyKill)
            EndSpawn?.Invoke();
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
