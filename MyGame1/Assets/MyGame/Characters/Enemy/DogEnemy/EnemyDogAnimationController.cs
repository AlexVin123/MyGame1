using UnityEngine;

public class EnemyDogAnimationController : EnemyAnimations
{

    private int _triggerMove = Animator.StringToHash("TriggerMove");
    private int _triggerAttack = Animator.StringToHash("TriggerAttack");
    private int _triggerIdle = Animator.StringToHash("TriggerIdle");

    public override void OnChaigeState(TypeState state)
    {
        switch (state)
        {
            case TypeState.Idle:
                Animator.SetTrigger(_triggerIdle);
                break;
            case TypeState.Attack:
                Animator.SetTrigger(_triggerAttack);
                break;
            case TypeState.Walk:
                Animator.SetTrigger(_triggerMove);
                break;
            case TypeState.NotState:
                Animator.SetTrigger(_triggerIdle);
                break;
        }
    }
}
