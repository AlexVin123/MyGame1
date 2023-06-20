using UnityEngine;
using UnityEngine.Events;

public class BurstDown : AbilityRB
{
    [SerializeField]private float _forge = 50f;
    [SerializeField] private Explosion _explosion;

    public UnityAction StartBurstDowm;

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);
    }

    public override void Perform()
    {
        StartBurstDowm?.Invoke();
        _explosion.Active = true;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(Vector2.down * _forge, ForceMode2D.Impulse);
    }
}
