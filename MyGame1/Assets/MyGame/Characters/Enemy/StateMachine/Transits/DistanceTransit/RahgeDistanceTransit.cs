using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahgeDistanceTransit : Transit
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minDistance;
    public override bool NeedTransit()
    {
        if(Enemy.CurrentTarget != null)
        {
            Debug.Log("Дистанция = " + Vector2.Distance(transform.position, Enemy.CurrentTarget.Position));

            if (Vector2.Distance(transform.position, Enemy.CurrentTarget.Position) > _minDistance && Vector2.Distance(transform.position, Enemy.CurrentTarget.Position) < _maxDistance)
                return true;
        }

        return false;


    }
}
