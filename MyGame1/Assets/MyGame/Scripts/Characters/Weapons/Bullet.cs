using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime = 5;

    private Timer _timer = new Timer(TypeTimer.UpdateTick);

    private void OnEnable()
    {
        _timer.TimerFinished += OnTimerFinish;
        _timer.Start(_lifetime);      
    }

    private void Update()
    {
        transform.Translate(-transform.up * _speed * Time.deltaTime, Space.World);
    }

    private void OnTimerFinish()
    {
        _timer.TimerFinished -= OnTimerFinish;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ITarget target))
        {
            target.TakeDamage(_damage);
            OnTimerFinish();
        }
    }
}
