using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDown : Ability
{
    private float _forg;

    public BurstDown(DataBasePlayer dataBasePlayer, Rigidbody2D rb) : base(dataBasePlayer, rb)
    {
        _forg = 40f;
    }

    public override void SetParameter()
    {
        
    }

    public void StartDown()
    {
        Rigidbody2D.AddForce(new Vector2(0f, -1 * _forg), ForceMode2D.Impulse);
    }
}
