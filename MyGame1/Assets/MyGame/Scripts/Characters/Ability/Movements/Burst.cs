using System.Collections;
using UnityEngine;

public class Burst : AbilityRB
{
    [SerializeField] private float _forge = 70f;
    [SerializeField] private float _distance;
    private bool _isActive = false;
    private Vector2 _targetPoint;
    private float _gravityScale;

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);

        if (parameters != null)
        {
            if (float.TryParse(parameters.GetValue(TypeParameter.DistanceBurst), out float result))
                _distance = result;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на float");
        }

        _gravityScale = Rigidbody.gravityScale;
    }

    public override void Perform(Vector2 direction)
    {
        StartCoroutine(StartBurst(direction));
    }

    private IEnumerator StartBurst(Vector2 direction)
    {
        int directonX = 0;

        if (direction.x > 0)
            directonX = 1;
        else if (direction.x < 0)
            directonX = -1;

        if (_isActive == false)
        {
            Rigidbody.velocity = Vector2.zero;
            _targetPoint = new Vector2(Rigidbody.position.x + _distance * directonX, Rigidbody.position.y);
            Rigidbody.gravityScale = 0;
            _isActive = true;
        }

        while (Mathf.Round(Rigidbody.position.x) != Mathf.Round(_targetPoint.x))
        {
            Rigidbody.position = Vector2.MoveTowards(Rigidbody.position, _targetPoint, _forge * Time.deltaTime);
            yield return null;
        }

        Rigidbody.gravityScale = _gravityScale;
        _isActive = false;
    }
}
