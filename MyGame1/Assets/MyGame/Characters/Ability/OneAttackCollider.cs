using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OneAttackCollider : MonoBehaviour
{
    private int _damage;

    public event UnityAction TakedDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ITarget target))
        {
            target.TakeDamage(_damage);
            TakedDamage?.Invoke();
        }

        gameObject.SetActive(false);
    }

    public void Init(int damage)
    {
        _damage = damage;
    }
}
