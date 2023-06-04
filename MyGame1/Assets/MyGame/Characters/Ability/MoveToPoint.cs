using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : Ability
{
    [SerializeField] private Ability _moveAbility;

    public override void Init(ICharacterParameters parameters)
    {
       
    }

    public override void Perform(Vector2 value)
    {
        Vector2 direction = value - (Vector2)transform.position;
        Debug.Log("Погнали");

        _moveAbility.Perform(direction.normalized);
    }
}
