using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BurstDown : AbilityRB
{
    [SerializeField]private float _forg = 50f;
    [SerializeField] private Explosion _explosion;

    private bool _isDamage = false;
    private float _damage;
    private float _forge;

    public UnityAction StartBurstDowm;

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);
    }

    public override void Perform()
    {
        StartBurstDowm?.Invoke();
        _explosion.Active = true;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(new Vector2(0f, -1 * _forg), ForceMode2D.Impulse);
    }
}
