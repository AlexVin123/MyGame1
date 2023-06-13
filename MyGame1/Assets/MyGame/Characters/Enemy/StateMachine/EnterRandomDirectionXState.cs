using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRandomDirectionXState : State
{
    public void Update()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Рывок");
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            Enemy.PerformAbility(Ability, Vector2.left);

        }
        else
        {
            Enemy.PerformAbility(Ability, Vector2.right);
        }


    }
}
