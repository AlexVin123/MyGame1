using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition<T>: MonoBehaviour where T : Enemy
{
    [SerializeField] private State<T> _state;

    protected GameObject Target;
    protected T Enemy;

    public State<T> State => _state;

    public bool NeedTransit { get ; protected set; }

    public abstract void Update();

    public virtual void Init(GameObject target,T enemy)
    {
        Enemy = enemy;
        Target = target;
        NeedTransit = false;
    }
}
