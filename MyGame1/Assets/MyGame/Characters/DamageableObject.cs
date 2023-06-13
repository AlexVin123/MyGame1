using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Health))]
public class DamageableObject : MonoBehaviour, ITarget
{
    [SerializeField] private TypeTarget _typeTarget;

    protected Health Health;

    public UnityAction<float, float> ChaigedHealth { get { return Health.ChangedHealt; } set { Health.ChangedHealt = value; } }

    public UnityAction TakedDamage;

    public UnityAction Dying;

    public Vector2 Position => transform.position;

    public virtual Vector2 LuckDirection => Vector2.down;

    public TypeTarget TargetType => _typeTarget;

    public virtual void Init(ICharacterConfig parameter = null)
    {
        Health = GetComponent<Health>();
        Health.Init(parameter);
    }

    public void TakeDamage(float damage)
    {
        TakedDamage?.Invoke();

        if(Health != null)
        {
            Health.TakeDamage(damage);

            if (Health.CurrentHealth == 0)
                Die();
        }

    }

    protected virtual void Die()
    {
        Dying?.Invoke();
        gameObject.SetActive(false);
    }

    public virtual void ResetParam()
    {
        if (Health != null)
            Health.Init();
    }
}
