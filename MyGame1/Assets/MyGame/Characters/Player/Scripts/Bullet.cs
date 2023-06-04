using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _timeLife;

    private Timer _timer;

    public void StartFly()
    {
        _timer = new Timer(TimerType.UpdateTick);
        _timer.OnTimerFinishedEvent += Destroy;
        _timer.Start(_timeLife);

        transform.Translate(transform.localEulerAngles * _speed * Time.deltaTime, Space.World);
    
    }

    private void Destroy()
    {
        _timer.OnTimerFinishedEvent -= Destroy;
        GameObject.Destroy(gameObject);
    }



    

}
