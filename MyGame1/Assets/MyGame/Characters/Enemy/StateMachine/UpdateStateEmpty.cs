using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStateEmpty : State
{
    private void Update()
    {
        Enemy.PerformAbility(Ability);
    }
}

