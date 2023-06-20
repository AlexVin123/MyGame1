using UnityEngine;

public class MoveToPoint : Ability
{
    [SerializeField] private Ability _moveAbility;

    public override void Init(ICharacterConfig parameters) {}

    public override void Perform(ITarget target)
    {
        Vector2 direction = target.Position - (Vector2)transform.position;
        _moveAbility.Perform(direction.normalized);
    }
}
