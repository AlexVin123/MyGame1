using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Statemachine/Transit/Distance")]
public class DistanceTransit : Transit
{
    [SerializeField] private int _value;
    [SerializeField] private DistanceType _type; 

    public override bool NeedTransit(Enemy enemy)
    {
        if(enemy.CurrentTarget == null)
            return false;

        float distance = Vector2.Distance(enemy.transform.position, enemy.CurrentTarget.Position());

        switch (_type)
        {
            case DistanceType.More:
                return distance < _value;
            case DistanceType.Less:
                return distance > _value;
            default:
                return false;
        }
    }
}

enum DistanceType
{
    More, Less
}
