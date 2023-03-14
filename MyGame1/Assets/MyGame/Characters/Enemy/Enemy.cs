using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected EnemyParameterData Parameters;
    [SerializeField] protected ControllerEnemyAnimations Anim;
    private SpriteRenderer[] _renders;
    private Health _health;

    protected Rigidbody2D Rigidbody;

    private float _timer;
    private Color _currentCollor;

    public void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }

        if(_timer<= 0)
        {
            ChaingeColor(_currentCollor);
        }
    }

    public virtual void Init(GameObject target)
    {
        Anim.Init();
        Rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _health.Init(Parameters);
        _renders = GetComponentsInChildren<SpriteRenderer>();
        _currentCollor = _renders[0].color;
    }

    public abstract void Move(Vector2 direction);

    public abstract void Attack();

    public void TakeDamage(float damage)
    {
        ChaingeColor(Color.red);
        _timer = 0.2f;
        _health.TakeDamage(damage);
        if (_health.IsDie)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void ChaingeColor(Color color)
    {
        if(_renders != null)
        {
            foreach (var r in _renders)
            {
                r.color = color;
            }
        }
   
    }
}
