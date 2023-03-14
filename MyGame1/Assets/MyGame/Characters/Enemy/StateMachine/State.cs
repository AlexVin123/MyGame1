using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State<T> : MonoBehaviour where T : Enemy
{
    [SerializeField]private List<Transition<T>> _transitions;
    [SerializeField]private TypeState _typeState;

    protected T Enemy;
    protected GameObject Target;

    public TypeState NameState => _typeState;
    
    public virtual void Init(T enemy, GameObject target)
    {
        Target = target;
        Enemy = enemy;
    }
     
    public virtual void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.Init(Target, Enemy);
                transition.enabled = true;
            }
        }
        
    }

    protected virtual void Update() { }

    public virtual void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public State<T> GetNextState()
    {
        foreach(Transition<T> transition in _transitions)
        {
            if (transition.NeedTransit == true)
                return transition.State;
        }
        return null;
    }
}
