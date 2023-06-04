using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DamageableObject : MonoBehaviour, ITarget
{
    private Health health;

    public void Awake()
    {
        health = GetComponent<Health>();
        health.Init(null);
    }

    public Vector2 Position()
    {
        return transform.position;
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);

        if (health.CurrentHealth == 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
