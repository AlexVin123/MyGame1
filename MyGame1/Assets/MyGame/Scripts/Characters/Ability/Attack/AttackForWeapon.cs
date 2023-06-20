using UnityEngine;

[RequireComponent(typeof(Aim))]
public class AttackForWeapon : Ability
{
    [SerializeField] private Weapon _weapon;

    private Aim _aim;

    public override void Init(ICharacterConfig parameters)
    {
        _aim = GetComponent<Aim>();
        _weapon.Init(parameters);
    }

    public override void Perform(ITarget target)
    {
        _aim.AimTarget(target.Position);
        _weapon.Shoot();
    }
}
