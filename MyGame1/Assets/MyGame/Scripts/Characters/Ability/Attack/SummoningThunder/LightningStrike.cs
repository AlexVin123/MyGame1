using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LightningStrike : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delay;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _audioSource;

    private ITarget _target;
    private WaitForSeconds _timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITarget target))
            _target = target;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITarget target))
            _target = target;
        else
            _target = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITarget target) && _target == target)
                _target = null;
    }

    public void Init()
    {
        _timer = new WaitForSeconds(_delay);
    }

    public void Perform()
    {
        StartCoroutine(Strike());
    }

    private IEnumerator Strike()
    {
        _particleSystem.Play();

        yield return _timer;

        float pitch = Random.Range(0.8f, 1.2f);
        _audioSource.pitch = pitch;
        _audioSource.Play();

        if (_target != null)
            _target.TakeDamage(_damage);

        yield return _timer;

        gameObject.SetActive(false);
    }
}
