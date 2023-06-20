using UnityEngine;

public class OneAttackForCollider : Ability
{
    [SerializeField] private OneAttackCollider _oneAttackColider;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifetime;

    private Timer _timerLifetime;

    private void OnDisable()
    {
        if(_timerLifetime != null)
        _timerLifetime.TimerFinished -= OnTimerFinish;
    }

    public override void Init(ICharacterConfig parameters)
    {
        _oneAttackColider.Init(_damage);
        _timerLifetime = new Timer(TypeTimer.UpdateTick);
        _timerLifetime.TimerFinished += OnTimerFinish;
        _oneAttackColider.gameObject.SetActive(false);
    }

    public override void Perform()
    {
        _timerLifetime.Start(_lifetime);
        _oneAttackColider.gameObject.SetActive(true);
    }

    private void OnTimerFinish()
    {
        _oneAttackColider.gameObject.SetActive(false);
    }
}
