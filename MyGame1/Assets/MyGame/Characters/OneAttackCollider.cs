using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OneAttackCollider : MonoBehaviour
{
    private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ITarget target))
            target.TakeDamage(_damage);

        gameObject.SetActive(false);
    }

    public void Init(int damage)
    {
        _damage = damage;
    }
}
