using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transit:MonoBehaviour
{
    [SerializeField] private string Discription;
   [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    protected Enemy Enemy;

    public virtual void Init(Enemy enemy)
    {
        Enemy = enemy;
    }

    public abstract bool NeedTransit();
}
