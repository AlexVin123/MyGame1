using UnityEngine;

public class PlayerLookTransition : Transit
{
    [SerializeField] private ContactFilter2D _contactFilter;

    public override bool NeedTransit()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];

        if (Enemy.CurrentTarget != null)
            Physics2D.Raycast(Enemy.CurrentTarget.Position, Enemy.CurrentTarget.LuckDirection, _contactFilter, hit, 100);

        if (hit[0])
            return gameObject == hit[0].collider.gameObject;
        else
            return false;
    }
}
