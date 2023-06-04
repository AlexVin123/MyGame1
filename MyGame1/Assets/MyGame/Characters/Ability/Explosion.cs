using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : AbilityRB
{
    [SerializeField] private float _radius;
    [SerializeField] private float _forge;
    [SerializeField] private Transform _point;

    public bool Active { get; set; }

    public override void Init(ICharacterParameters parameters)
    {
        base.Init(parameters);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Active)
            Perform();
    }

    public override void Perform()
    {
        Collider2D[] collaiders = Physics2D.OverlapCircleAll(_point.position, _radius);

        for (int i = 0; i < collaiders.Length; i++)
        {
            Rigidbody2D rb = collaiders[i].attachedRigidbody;

            if (rb)
            {
                if (Rigidbody != rb)
                    AddExplouseForge(rb, _forge);


                Debug.Log("Âçðûûûûâ öåëèâ");
            }
        }
        Debug.Log("Âçðûûûûâ");

        Active = false;
    }

    private void AddExplouseForge(Rigidbody2D rb, float forge)
    {
        Vector2 direction = (rb.position - (Vector2)_point.position).normalized;
        direction *= forge;
        rb.AddForce(direction, ForceMode2D.Impulse);
    }
}
