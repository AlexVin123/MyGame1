using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected Rigidbody2D Rigidbody2D;

    public Ability(Rigidbody2D rb)
    {
        Rigidbody2D = rb;
    }
}
