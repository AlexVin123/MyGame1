using System.Collections;
using UnityEngine;

public class WaveAttack : Ability
{
    [SerializeField] private WaveAttackPrefab _prefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _delay = 0.8f;
    [SerializeField] private int _countInPool = 5;

    private PoolMono<WaveAttackPrefab> _pool;
    private WaitForSeconds _timerDelay;

    public override void Init(ICharacterConfig parameters)
    {
        _timerDelay = new WaitForSeconds(_delay);
        _pool = new PoolMono<WaveAttackPrefab>(_prefab, _countInPool);
        var all = _pool.GetAllElements();

        foreach (var item in all)
            item.Init(); 
    }

    public override void Perform()
    {
        StartCoroutine(StartWave());
    }

    public IEnumerator StartWave()
    {
        yield return _timerDelay;

        _pool.GetFreeElement(_startPoint.position, _startPoint.rotation);
    }
}
