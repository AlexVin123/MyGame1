using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;

    private Timer _timer = new Timer(TypeTimer.UpdateTick);

    private void OnEnable()
    {
        _timer.OnTimerFinishedEvent += Disable;
        _timer.Start(5);
        //_rb.velocity = -transform.up * _speed;
        
    }

    private void Update()
    {
        transform.Translate(-transform.up * _speed * Time.deltaTime, Space.World);
    }

    private void Disable()
    {
        _timer.OnTimerFinishedEvent -= Disable;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ITarget target))
        {
            target.TakeDamage(_damage);
            Disable();
        }
    }
}
