using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDown : Ability
{
    private float _forg;

    public BurstDown(Rigidbody2D rb) : base(rb)
    {
        _forg = 90f;
    }

    public void StartDown()
    {
        Rigidbody2D.velocity = Vector2.zero;
        Rigidbody2D.AddForce(new Vector2(0f, -1 * _forg), ForceMode2D.Impulse);
    }
}
