using UnityEngine;

public abstract class Transit:MonoBehaviour
{
   [SerializeField] private State _targetState;

    protected Enemy Enemy;

    public State TargetState => _targetState;

    public virtual void Init(Enemy enemy)
    {
        Enemy = enemy;
    }

    public abstract bool NeedTransit();
}
