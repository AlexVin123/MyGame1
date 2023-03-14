using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDown : AbilityRB
{
    [SerializeField]private float _forg = 50f;

    private bool _isDamage = false;
    private float _damage;
    private float _forge;

    public override void Init(DataBase dataPlayer)
    {
        base.Init(dataPlayer);
    }

    public void StartDown()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(new Vector2(0f, -1 * _forg), ForceMode2D.Impulse);
    }
}
