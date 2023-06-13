using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollaider : MonoBehaviour
{
    private float _speedAttack;
    private float _damage;
    private ITarget _target;
    private Timer _timer;
    private bool _isInit = false;

    private void OnEnable()
    {
        if (_isInit)
        {
            _timer.OnTimerFinishedEvent += StartTimer;
            _timer.OnTimerFinishedEvent += Attack;

            if (_timer.IsPaused)
            {
                _timer.UnPause();
            }
            else if (_timer.RemainingSecond == 0)
            {
                Attack();
                StartTimer();
            }

        }

    }

    private void OnDisable()
    {
        if (_isInit)
        {
            _timer.Pause();
            _timer.OnTimerFinishedEvent -= StartTimer;
            _timer.OnTimerFinishedEvent -= Attack;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out ITarget target))
        {
            _target = target;
        }
        else
            _target = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ITarget target))
        {
            _target = null;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.transform.TryGetComponent(out ITarget target))
    //        _target = target;
    //    else
    //        _target = null;
    //}

    public void Init(float damge, float speedAttack)
    {
        _damage = damge;
        _speedAttack = speedAttack;
        _timer = new Timer(TypeTimer.UpdateTick);
        _isInit = true;
    }

    private void StartTimer()
    {
        _timer.Start(_speedAttack);
    }


    private void Attack()
    {

        if (_target != null)
        {
            _target.TakeDamage(_damage);
        }
    }
}
