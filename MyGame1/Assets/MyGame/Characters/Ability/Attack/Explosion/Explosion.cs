using UnityEngine;
using UnityEngine.Events;

public class Explosion : AbilityRB
{
    [SerializeField] private float _radius;
    [SerializeField] private float _forge;
    [SerializeField] private Transform _point;
    [SerializeField] private int _damage;

    public bool Active { get; set; }

    public event UnityAction StartedExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Active)
        {
            StartedExplosion?.Invoke();
            Perform();
        }
    }

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);

        if (parameters != null)
        {

            if (int.TryParse(parameters.GetValue(TypeParameter.DamageExplose), out int result))
                _damage = result;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на int");

            if (int.TryParse(parameters.GetValue(TypeParameter.ForgeExplose), out int result2))
                _forge = result2;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на int");
        }
    }

    public override void Perform()
    {
        Collider2D[] collaiders = Physics2D.OverlapCircleAll(_point.position, _radius);

        for (int i = 0; i < collaiders.Length; i++)
        {
            if (collaiders[i].TryGetComponent(out ITarget enemy))
            {
                Rigidbody2D rigidbody = collaiders[i].attachedRigidbody;

                if (rigidbody)
                {
                    if (Rigidbody != rigidbody)
                    {
                        enemy.TakeDamage(_damage);
                        AddExplosionForge(rigidbody, _forge);
                    }
                }
            }
        }

        Active = false;
    }

    private void AddExplosionForge(Rigidbody2D rigidbody, float forge)
    {
        Vector2 direction = (rigidbody.position - (Vector2)_point.position).normalized;
        direction *= forge;
        rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }
}
