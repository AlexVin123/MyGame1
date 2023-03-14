using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAnimationsDog : ControllerEnemyAnimations
{
    private int _triggerMove = Animator.StringToHash("TriggerMove");
    private int _triggerAttack = Animator.StringToHash("TriggerAttack");
    private int _triggerIdle = Animator.StringToHash("TriggerIdle");

    public override void OnChaingeState(TypeState state)
    {
        switch(state)
        {
            case TypeState.Idle:
                AnimatorEnemy.SetTrigger(_triggerIdle);
                break;
                case TypeState.Attack:
                AnimatorEnemy.SetTrigger(_triggerAttack);
                Debug.Log("TrigerAttack++++++++++++++++++");
                break;
                case TypeState.Move:
                AnimatorEnemy.SetTrigger(_triggerMove);
                break;
        }
    }
}
