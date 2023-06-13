using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleWaitState : State
{
    [SerializeField] private State _state1;
    [SerializeField] private State _state2;
    [SerializeField] private float _timeWait;

    private bool _isEnd;

    private Timer _timer = new Timer(TypeTimer.OneSecTick);

    private void Update()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        _isEnd = false;
        _timer.OnTimerFinishedEvent += End;
        _timer.Start(_timeWait);
        _state1.enabled = true;
        _state1.Enter();
        _state2.enabled = true;
        _state2.Enter();

    }

    public override void Exit()
    {
        _timer.OnTimerFinishedEvent -= End;
        base.Exit();
        _state1.Exit();
        _state1.enabled = false;
        _state2.Exit();
        _state2.enabled = false;
    }

    public override State GetNextState()
    {
        if (_isEnd)
            return base.GetNextState();
        else
            return null;
    }

    public void End()
    {
        _isEnd = true;
    }
}
