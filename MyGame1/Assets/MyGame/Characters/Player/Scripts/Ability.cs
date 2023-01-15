using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected DataBasePlayer DataBasePlayer;
    protected Rigidbody2D Rigidbody2D;

    public Ability(DataBasePlayer dataBasePlayer, Rigidbody2D rb)
    {
        DataBasePlayer = dataBasePlayer;
        Rigidbody2D = rb;
    }

    public abstract void SetParameter();
}
