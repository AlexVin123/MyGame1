using UnityEngine;

public class BossAnimatorController : EnemyAnimations
{
    [SerializeField] private BossEnemySounds _sounds;

    private int _triggerIdle = Animator.StringToHash("TriggerIdle");
    private int _triggerWalk = Animator.StringToHash("TriggerWalk");
    private int _triggerJump = Animator.StringToHash("TriggerJump");
    private int _triggerAttack = Animator.StringToHash("TriggerAttack");
    private int _triggerUlt = Animator.StringToHash("TriggerUlt");


    public override void OnChaigeState(TypeState state)
    {
        if (state == TypeState.State1)
            _sounds.PlaySummoningThunder();
        else
            _sounds.StopSummoningThunder();

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
                Animator.SetTrigger(_triggerUlt);
                break;
            case TypeState.State2:
                Animator.SetTrigger(_triggerJump);
                break;
            case TypeState.State3:
                break;
            default:
                break;
        }
    }
}
