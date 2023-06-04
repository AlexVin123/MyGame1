using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statemachine/Transit/Target")]
public class TargetTransit : Transit
{
    [SerializeField] private TypeTarget typeTarget;

    public override bool NeedTransit(Enemy enemy)
    {
        switch (typeTarget)
        {
            case TypeTarget.True:
                return enemy.CurrentTarget != null;
            case TypeTarget.False:
                return enemy.CurrentTarget == null;
            default:
                return false;
        }
    }
}

enum TypeTarget
{
    True, False
}
