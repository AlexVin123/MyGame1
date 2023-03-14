using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ControllerEnemyAnimations : MonoBehaviour
{
    protected Animator AnimatorEnemy;

    public void Init()
    {
        AnimatorEnemy = GetComponentInChildren<Animator>();
    }

    public abstract void OnChaingeState(TypeState state);
}
