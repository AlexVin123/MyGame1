using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : AbilityRB
{
    [SerializeField] private float _forgeBurst = 70f;
    private float _distanceBurst;
    private bool _isBurst = false;
    private Vector2 _targetPoint;

    public override void Init(DataBase dataPlayer)
    {
        base.Init(dataPlayer);
        _distanceBurst = float.Parse(dataPlayer.GetParameter(TypeParameter.DistanceBurst));
        Debug.Log(_distanceBurst);
    }

    public IEnumerator StartBurst(float directionX)
    {
        float gravityScale = 0;
        
        if (_isBurst == false)
        {
            Rigidbody.velocity = Vector2.zero;
            _targetPoint = new Vector2(Rigidbody.position.x + _distanceBurst * directionX, Rigidbody.position.y);
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
