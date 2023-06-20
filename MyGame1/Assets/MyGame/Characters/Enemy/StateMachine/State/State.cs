using UnityEngine;


public abstract class State : MonoBehaviour
{
    [SerializeField] protected TypeAbility Ability;
    [SerializeField] protected TypeState StateType;

    [SerializeField] private float _timeAction;
    [SerializeField] private Transit[] _transitions;

    protected Enemy Enemy;
    private Timer _timer;
    private bool _isActiveAbility;

    public TypeAbility TypeAbility => Ability;
    public TypeState TypeState => StateType;


    private void Update(){}

    public void Init(Enemy enemy)
    {
        _timer = new Timer(TypeTimer.UpdateTick);
        Enemy = enemy;
    }

    public virtual void Enter()
    {
        _isActiveAbility = true;
        _timer.TimerFinished += OnFinishTimer;
        _timer.Start(_timeAction);

        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Enemy);
            }
        }
    }

    public virtual void Exit()
    {
        _timer.TimerFinished -= OnFinishTimer;

        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public virtual State GetNextState()
    {
        if(_isActiveAbility == false)
        {
            foreach (var transition in _transitions)
            {
                if (transition.NeedTransit())
                    return transition.TargetState;
            }
        }

        return null;
    }

    private void OnFinishTimer()
    {
        _isActiveAbility = false;
    }
}
