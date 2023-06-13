using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : AbilityRB
{
    [SerializeField] private float _radius;
    [SerializeField] private float _forge;
    [SerializeField] private Transform _point;
    [SerializeField] private int _damage;

    public bool Active { get; set; }
    public UnityAction StartExploson;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Active)
        {
            StartExploson?.Invoke();
            Perform();
        }
    }

    public override void Perform()
    {
        Collider2D[] collaiders = Physics2D.OverlapCircleAll(_point.position, _radius);

        for (int i = 0; i < collaiders.Length; i++)
        {
            if (collaiders[i].TryGetComponent(out Enemy enemy))
            {
                Rigidbody2D rb = collaiders[i].attachedRigidbody;

                if (rb)
                {
                    if (Rigidbody != rb)
                    {
                        enemy.TakeDamage(_damage);
                        AddExplouseForge(rb, _forge);
                    }


                    Debug.Log("Взрыыыыв целив");
                }
            }
        }
        Debug.Log("Взрыыыыв");

        Active = false;
    }

    private void AddExplouseForge(Rigidbody2D rb, float forge)
    {
        Vector2 direction = (rb.position - (Vector2)_point.position).normalized;
        direction *= forge;
        rb.AddForce(direction, ForceMode2D.Impulse);
    }
}
