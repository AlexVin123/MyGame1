using UnityEngine;

[RequireComponent(typeof(Burst))]
[RequireComponent (typeof(OneAttackForCollider))]
public class BurstAttack : Ability
{
    private Burst _burst;
    private OneAttackForCollider _oneAttackForCollider;

    public override void Init(ICharacterConfig parameters)
    {
        _burst = GetComponent<Burst>();
        _oneAttackForCollider = GetComponent<OneAttackForCollider>();
        _burst.Init(parameters);
        _oneAttackForCollider.Init(parameters);
    }

    public override void Perform(ITarget target)
    {
        _oneAttackForCollider.Perform();
        Vector2 direction = target.Position - (Vector2)transform.position;

        if (direction.x > 0)
            direction.x = 1;
        else
            direction.x = -1;

        _burst.Perform(direction);
    }
}
