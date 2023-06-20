using UnityEngine;

[RequireComponent(typeof(OneAttackCollider))]
public class WaveAttackPrefab : MonoBehaviour
{
    [SerializeField] private int _speed = 20;
    [SerializeField] private int _lifetime = 5;
    [SerializeField] private int _damage = 20;

    private OneAttackCollider _oneAttackCollider;
    private Timer _timerLifetime;

    private void OnEnable()
    {
        if (_timerLifetime != null)
        {
            _timerLifetime.TimerFinished += OnTimerFinish;
            _timerLifetime.Start(_lifetime);
        }

        if (_oneAttackCollider != null)
            _oneAttackCollider.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if(_timerLifetime != null )
        _timerLifetime.TimerFinished -= OnDisable;
    }

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
    }

    public void Init()
    {
        _oneAttackCollider = GetComponent<OneAttackCollider>();
        _oneAttackCollider.Init(_damage);
        _timerLifetime = new Timer(TypeTimer.UpdateTick);
    }

    private void OnTimerFinish()
    {
        gameObject.SetActive(false);
    }
}
