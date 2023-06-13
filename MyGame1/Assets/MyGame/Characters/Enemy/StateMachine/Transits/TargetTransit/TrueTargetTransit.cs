using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueTargetTransit : Transit
{
    public override bool NeedTransit()
    {
        return Enemy.CurrentTarget != null;
    }
}


