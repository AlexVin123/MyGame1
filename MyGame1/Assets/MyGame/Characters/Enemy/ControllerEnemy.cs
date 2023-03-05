using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerEnemy<T,B> : MonoBehaviour where T : StateMachineEnemy<B> where B : Enemy
{
    [SerializeField] private T _stateMachine;
    private B enemy;
    private GameObject target;

    private void Awake()
    {
        enemy = GetComponent<B>();
        enemy.Init();
        target = enemy.Target;
        _stateMachine.Init(enemy, target);
    }

    public virtual void Update()
    {
        _stateMachine.Upgrate();
    }
}
