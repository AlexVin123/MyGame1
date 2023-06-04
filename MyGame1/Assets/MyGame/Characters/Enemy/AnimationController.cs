using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private int _triggerMove = Animator.StringToHash("TriggerMove");
    private int _triggerAttack = Animator.StringToHash("TriggerAttack");
    private int _triggerIdle = Animator.StringToHash("TriggerIdle");

    public void Init()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void StartAnimation(TypeState state)
    {
        Debug.Log("AAAAAAA");
        switch (state)
        {
            case TypeState.Idle:
                _animator.SetTrigger(_triggerIdle);
                break;
            case TypeState.Attack:
                _animator.SetTrigger(_triggerAttack);
                Debug.Log("TrigerAttack++++++++++++++++++");
                break;
            case TypeState.Walk:
                _animator.SetTrigger(_triggerMove);
                break;
            case TypeState.NotState:
                _animator.SetTrigger(_triggerIdle);
                break;
        }
    }
}
