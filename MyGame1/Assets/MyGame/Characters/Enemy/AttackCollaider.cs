using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollaider : MonoBehaviour
{
    private float _speedAttack;
    private float _damage;
    private ITarget _target;
    private Timer _timer;

    private void OnEnable()
    {
            StartAttack();
    }

    private void OnDisable()
    {
        if(_timer.TryEmpty() == false)
        _timer.OnTimerFinishedEvent -= StartAttack;
        _timer.Stop();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ITarget target))
            _target = target;
        else
            _target = null;
    }

    public void Init(float damge, float speedAttack)
    {
        _damage = damge;
        _speedAttack = speedAttack;
        _timer = new Timer(TimerType.UpdateTick);
    }

    private void StartAttack()
    {
        Attack();
        if (_timer.TryEmpty() == false)
            _timer.OnTimerFinishedEvent -= StartAttack;

        _timer.OnTimerFinishedEvent += StartAttack;
        _timer.Start(_speedAttack);
    }


    private void Attack()
    {
        Debug.Log("Attack: " + _target);

        if (_target != null)
        {
            _target.TakeDamage(_damage);
        }
    }
}
