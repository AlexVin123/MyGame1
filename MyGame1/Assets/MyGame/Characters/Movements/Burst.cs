using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : Ability
{
    private float _forgeBurst;
    private DistanceBurst _distanceBurst;
    private bool _isBurst = false;
    private Vector2 _targetPoint;

    public Burst(DataBasePlayer dataBasePlayer, Rigidbody2D rb) : base(dataBasePlayer, rb)
    {
        _forgeBurst = 40f;
    }

    public override void SetParameter()
    {
        _distanceBurst = (DistanceBurst)DataBasePlayer.GetParameter(ParametersPlayer.DistanceBurst);
    }

    public IEnumerator StartBurst(float directionX)
    {
        if(_isBurst == false)
        {
            _targetPoint = new Vector2(Rigidbody2D.position.x + _distanceBurst.Value * directionX, Rigidbody2D.position.y);
            _isBurst = true;
        }

        while(Mathf.Round(Rigidbody2D.position.x) != Mathf.Round(_targetPoint.x))
        {
            Rigidbody2D.position = Vector2.MoveTowards(Rigidbody2D.position, _targetPoint, _forgeBurst * Time.deltaTime);
        yield return null;
        }      
            _isBurst = false;       
    }
}
