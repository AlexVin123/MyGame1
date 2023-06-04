using System.Collections;
using UnityEngine;

public class Burst : AbilityRB
{
    [SerializeField] private float _forgeBurst = 70f;
    [SerializeField] private float _distanceBurst;
    private bool _isBurst = false;
    private Vector2 _targetPoint;

    public override void Init(ICharacterParameters parameters)
    {
        base.Init(parameters);

        if (parameters != null)
        {

            if (float.TryParse(parameters.GetValue(TypeParameter.DistanceBurst), out float result))
                _distanceBurst = result;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на float");
        }
    }

    public override void Perform(Vector2 direction)
    {
        StartCoroutine(StartBurst(direction));
    }

    public IEnumerator StartBurst(Vector2 direction)
    {
        float gravityScale = 0;

        if (_isBurst == false)
        {
            Rigidbody.velocity = Vector2.zero;
            _targetPoint = new Vector2(Rigidbody.position.x + _distanceBurst * direction.x, Rigidbody.position.y);
            gravityScale = Rigidbody.gravityScale;
            Rigidbody.gravityScale = 0;
            _isBurst = true;
        }

        while (Mathf.Round(Rigidbody.position.x) != Mathf.Round(_targetPoint.x))
        {
            Rigidbody.position = Vector2.MoveTowards(Rigidbody.position, _targetPoint, _forgeBurst * Time.deltaTime);
            yield return null;
        }
        Rigidbody.gravityScale = gravityScale;
        _isBurst = false;
    }
}
