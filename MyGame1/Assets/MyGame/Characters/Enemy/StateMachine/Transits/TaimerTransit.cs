using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaimerTransit<T> : Transition<T> where T : Enemy
{
    [SerializeField] private float _seconds;

    private float _timer;

    public override void Init(GameObject target, T enemy)
    {
        base.Init(target, enemy);
        _timer = _seconds;
    }

    public override void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            NeedTransit = true;
        }
    }
}

namespace EnemyDog
{
    public class TaimerTransit : TaimerTransit<EnemyDog> { }
}
