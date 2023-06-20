using UnityEngine;

[RequireComponent(typeof(Jump))]
[RequireComponent (typeof(Explosion))]
public class AttackJump : Ability
{
    private Jump _jump;
    private Explosion _explosion;

    public override void Init(ICharacterConfig parameters)
    {
        _jump = GetComponent<Jump>();
        _explosion = GetComponent<Explosion>();
        _jump.Init(parameters);
        _explosion.Init(parameters);
    }

    public override void Perform()
    {
        _jump.Perform();
        _explosion.Active = true;
    }
}
