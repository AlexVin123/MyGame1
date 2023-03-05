using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : Ability
{
    private float _forgeBurst;
    private float _distanceBurst;
    private bool _isBurst = false;
    private Vector2 _targetPoint;

    public Burst(float distanceBurst, Rigidbody2D rb) : base(rb)
    {
        _distanceBurst = distanceBurst;
        _forgeBurst = 70f;
    }

    public IEnumerator StartBurst(float directionX)
    {
        float gravityScale = 0;
        
        if (_isBurst == false)
        {
            Rigidbody2D.velocity = Vector2.zero;
            _targetPoint = new Vector2(Rigidbody2D.position.x + _distanceBurst * directionX, Rigidbody2D.position.y);
            gravityScale = Rigidbody2D.gravityScale;
            Rigidbody2D.gravityScale = 0;
            _isBurst = true;
        }

        while (Mathf.Round(Rigidbody2D.position.x) != Mathf.Round(_targetPoint.x))
        {
            Rigidbody2D.position = Vector2.MoveTowards(Rigidbody2D.position, _targetPoint, _forgeBurst * Time.deltaTime);
            yield return null;
        }
        Rigidbody2D.gravityScale = gravityScale;
        _isBurst = false;
    }
}
