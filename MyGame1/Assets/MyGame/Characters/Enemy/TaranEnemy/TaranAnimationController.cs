using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaranAnimationController : AnimatorController
{
    private int _triggerIdle = Animator.StringToHash("TriggerIdle");
    private int _triggerAttack = Animator.StringToHash("TriggerAttack");
    private int _triggerBurst = Animator.StringToHash("TriggerBurst");
    private int _triggerWalk = Animator.StringToHash("TriggerWalk");

    public override void OnChaigedState(TypeState state)
    {
        switch (state)
        {
            case TypeState.NotState:
                break;
            case TypeState.Idle:
                Animator.SetTrigger(_triggerIdle);
                break;
            case TypeState.Walk:
                Animator.SetTrigger(_triggerWalk);
                break;
            case TypeState.Attack:
                Animator.SetTrigger(_triggerAttack);
                break;
            case TypeState.State1:
                Animator.SetTrigger(_triggerBurst);
                break;
            case TypeState.State2:
                break;
            case TypeState.State3:
                break;
            default:
                break;
        }
    }
}
