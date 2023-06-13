using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStateVector2 : State
{
    [SerializeField] private Vector2 _vector2;

    private Vector2 _current;

    public override void Enter()
    {
        base.Enter();
        _current = _vector2;
    }

    private void Update()
    {
        Enemy.PerformAbility(Ability, _current);
    }

    public override void Exit()
    {
        base.Exit();
        _current = Vector2.zero;
        Enemy.PerformAbility(Ability, _current);
    }
}
