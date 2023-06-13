using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract  class AnimatorController : MonoBehaviour
{
    protected Animator Animator;

    public void Init()
    {
        Animator = GetComponent<Animator>();
    }

    public abstract void OnChaigedState(TypeState state);
}
