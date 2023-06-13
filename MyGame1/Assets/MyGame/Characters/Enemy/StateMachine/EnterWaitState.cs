using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWaitState : State
{
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

        if(Ability != TypeAbility.None)
            Enemy.PerformAbility(Ability);
        
    }

    public override void Exit()
    {
        _timer.OnTimerFinishedEvent -= End;
        base.Exit();
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
