using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class AbilityRB : Ability
{
    protected Rigidbody2D Rigidbody;

    public override void Init(DataBase dataPlayer)
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
}
