using UnityEngine;

public class MovementDirectionX : AbilityRB
{
    [SerializeField] private float _accelerate = 40;
    [SerializeField] private float _maxSpeed;
    private float _speed;
    private float _targetSpeed;

    public override void Init(ICharacterConfig parametrs)
    {
        base.Init(parametrs);

        if (parametrs != null)
        {
            if (float.TryParse(parametrs.GetValue(TypeParameter.MaxSpeedMovement), out float result))
                _maxSpeed = result;
            else
                throw new System.FormatException("Конвертация не возможна, измените параметер на float");
        }
    }

    public override void Perform(Vector2 direction)
    {
        _targetSpeed = _maxSpeed * direction.x;
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        Rigidbody.velocity = new Vector2(_speed, Rigidbody.velocity.y);
    }
}
