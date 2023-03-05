using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability
{
    private float _forge;

    public Jump(float forge, Rigidbody2D rb) : base( rb)
    {
        _forge = forge;
    }

    public void StartJump(DefenitionCollisions defenitionCollisions)
    {

        Rigidbody2D.AddForce(new Vector2(0f, 1 * _forge), ForceMode2D.Impulse);
    }
}
