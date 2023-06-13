using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookTransition : Transit
{
    [SerializeField]private ContactFilter2D _contactFilter;

    public override bool NeedTransit()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];

        if(Enemy.CurrentTarget != null)
        {
        Physics2D.Raycast(Enemy.CurrentTarget.Position, Enemy.CurrentTarget.LuckDirection, _contactFilter, hit,100);
        Debug.DrawRay(Enemy.CurrentTarget.Position, Enemy.CurrentTarget.LuckDirection, Color.red, 2);

        }


        
        if(hit[0])
        Debug.Log(hit[0].collider.name);

        if (hit[0])
        {
            return gameObject == hit[0].collider.gameObject;
        }
        else
            return false;
    }
}
