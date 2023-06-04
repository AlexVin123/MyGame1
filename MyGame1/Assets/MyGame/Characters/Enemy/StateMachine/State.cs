using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : MonoBehaviour
{
    [SerializeField] protected TypeAbility Ability;
    [SerializeField] protected TypeState StateType;

    public TypeAbility TypeAbility => Ability;
    public TypeState TypeState => StateType;

    protected Enemy Enemy;

    public virtual void Enter(Enemy enemy)
    {
        Enemy = enemy;
        enabled = true;
    }

    public virtual void Exit()
    {
        enabled = false;
    }
}
