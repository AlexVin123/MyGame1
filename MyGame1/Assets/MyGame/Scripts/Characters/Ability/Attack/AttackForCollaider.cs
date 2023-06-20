using UnityEngine;

public class AttackForCollaider : Ability
{
    [SerializeField] private int _damage;
    [SerializeField]private ZoneAttack _zoneAttack;

    public override void Init(ICharacterConfig parameters){ }

    public override void Perform()
    {
        if (_zoneAttack.Target != null)
            _zoneAttack.Target.TakeDamage(_damage);
    }
}
