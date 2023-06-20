using System.Collections;
using UnityEngine;

public class SummoningThunder : Ability
{
    [SerializeField] private float _delayBeforeStart;
    [SerializeField] private float _deleyBettwenStrike;
    [SerializeField] private int _countStrike = 20;
    [SerializeField] private float _range = 40;
    [SerializeField] private LightningStrike _strikePrefab;
    [SerializeField] private ParticleSystem _startPartical;
    [SerializeField] private PoolMono<LightningStrike> _pool;
    [SerializeField] private Transform _startPoint;

    private int _sizePool = 20;
    private WaitForSeconds _timerDelayBefoteStart;
    private WaitForSeconds _timerDelayBettwenStrike;
    private Vector2 _positionStrike;

    public override void Init(ICharacterConfig config)
    {
        _positionStrike = Vector2.zero;
        _timerDelayBettwenStrike = new WaitForSeconds(_deleyBettwenStrike);
        _timerDelayBefoteStart = new WaitForSeconds(_delayBeforeStart);
        _pool = new PoolMono<LightningStrike>(_strikePrefab, _sizePool);
        var allElement = _pool.GetAllElements();

        foreach (var element in allElement)
            element.Init();
    }

    public override void Perform()
    {
        StartCoroutine(Striked());
    }

    private IEnumerator Striked()
    {
        _startPartical.Play();

        yield return _timerDelayBefoteStart;

        for (int i = 0; i < _countStrike; i++)
        {
            CreateStrike();
            yield return _timerDelayBettwenStrike;
        }

        _startPartical.Stop();
    }

    private void CreateStrike()
    {
        _positionStrike.x = Random.Range(_startPoint.position.x + _range, _startPoint.position.x - _range);
        _positionStrike.y = _startPoint.position.y;
        var strike = _pool.GetFreeElement(_positionStrike);
        strike.Perform();
    }
}
