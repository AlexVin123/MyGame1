using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : MonoBehaviour
{
    [SerializeField] protected TypeAbility Ability;
    [SerializeField] protected TypeState StateType;
    [SerializeField] protected Transit[] _transitions;

    public TypeAbility TypeAbility => Ability;
    public TypeState TypeState => StateType;

    protected Enemy Enemy;

    public void Init(Enemy enemy)
    {
        Enemy = enemy;
    }

    public virtual void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Enemy);
            }
        }
    }

    public virtual void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public virtual State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit())
                return transition.TargetState;
        }

        return null;
    }
}
