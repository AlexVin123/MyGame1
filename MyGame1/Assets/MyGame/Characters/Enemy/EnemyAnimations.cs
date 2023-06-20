using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract  class EnemyAnimations : MonoBehaviour
{
    protected Animator Animator;
    public void Init()
    {
        Animator = GetComponent<Animator>();
    }

    public abstract void OnChaigeState(TypeState state);
}
