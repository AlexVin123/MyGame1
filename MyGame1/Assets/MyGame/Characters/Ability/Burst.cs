using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Burst : AbilityRB
{
    [SerializeField] private float _forgeBurst = 70f;
    [SerializeField] private float _distanceBurst;
    private bool _isBurst = false;
    private Vector2 _targetPoint;
    private float _gravityScale;
    private Coroutine _coroutine;

    public override void Init(ICharacterConfig parameters)
    {
        base.Init(parameters);

        if (parameters != null)
        {

            if (float.TryParse(parameters.GetValue(TypeParameter.DistanceBurst), out float result))
                _distanceBurst = result;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на float");
        }

        _gravityScale = Rigidbody.gravityScale;
    }

    public override void Perform(Vector2 direction)
    {
        _coroutine = StartCoroutine(StartBurst(direction));
    }

    public IEnumerator StartBurst(Vector2 direction)
    {
        int directonX = 0;

        Debug.Log(direction.x);

        if (direction.x > 0)
            directonX = 1;
        else if (direction.x < 0)
            directonX = -1;

        Debug.Log(directonX);

        if (_isBurst == false)
        {
            Rigidbody.velocity = Vector2.zero;
            _targetPoint = new Vector2(Rigidbody.position.x + _distanceBurst * directonX, Rigidbody.position.y);
            Rigidbody.gravityScale = 0;
            _isBurst = true;
        }

        while (Mathf.Round(Rigidbody.position.x) != Mathf.Round(_targetPoint.x))
        {
            Rigidbody.position = Vector2.MoveTowards(Rigidbody.position, _targetPoint, _forgeBurst * Time.deltaTime);
            yield return null;
        }

        Rigidbody.gravityScale = _gravityScale;
        _isBurst = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Колизия!!");

        //if (_coroutine != null)
        //    StopCoroutine(_coroutine);

        //Rigidbody.gravityScale = _gravityScale;
    }
}
