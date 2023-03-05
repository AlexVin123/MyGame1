using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Dictionary<TypeParameter, Parameter> Parameters;
    private Health health;
    [SerializeField]private GameObject _target;

    public GameObject Target => _target;
    protected Rigidbody2D Rigidbody;

    public void SetParameters(Dictionary<TypeParameter,Parameter> parameters)
    {
        Parameters = parameters;
    }

    public virtual void Init()
    {
        Rigidbody = GetComponent<Rigidbody2D>(); 
        health = new Health(10);
    }

    public abstract void Move(Vector2 direction);

    public abstract void Attack();

    private void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }

    private void Die()
    {

    }
}
