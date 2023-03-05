using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> : ScriptableObject where T : Enemy
{
    protected T Enemy;
    protected GameObject _target;
    [SerializeField]private List<Transition<T>> _transitions;
    
    public void Init(T enemy, GameObject target)
    {
        _target = target;
        Enemy = enemy;
    }

     
    public virtual void Enter()
    {
        foreach (var transition in _transitions)
        {
            transition.Init(_target, Enemy);
        }
    }

    public virtual void Exit()
    {

    }

    public abstract void Update();

    protected void Check()
    {
        foreach(var transition in _transitions)
        {
            transition.ConditionalTest();
        }
    }

    public State<T> GetNextState()
    {
        foreach(var tran in _transitions)
        {
            if (tran.NeedTransit == true)
                return tran.State;
        }
        return null;
    }
}
