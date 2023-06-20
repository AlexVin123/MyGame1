using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _triggerIdle = Animator.StringToHash("TriggerIdle");
    private int _triggerWalk = Animator.StringToHash("TriggerWalk");

    public void Init()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerIdle()
    {
        _animator?.SetTrigger(_triggerIdle);
    }

    public void TriggerWalk()
    {
        _animator?.SetTrigger(_triggerWalk);
    }
}
