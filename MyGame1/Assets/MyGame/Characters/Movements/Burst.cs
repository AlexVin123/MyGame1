using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst :IControllerAbillities
{
    private float _forgeBurst;
    private Transform _playerTransform;
    private float _distanceBurst;
    private bool _isBurst = false;
    private Vector2 _targetPoint;

    public Burst(float distanceBurst, Transform playerTransform)
    {
        _forgeBurst = 30f;
        _distanceBurst = distanceBurst;
        _playerTransform = playerTransform;
    }

    public IEnumerator StartBurst(float directionX)
    {
        if(_isBurst == false)
        {
            _targetPoint = new Vector2(_playerTransform.position.x + _distanceBurst * directionX, _playerTransform.position.y);
            _isBurst = true;
        }

        while(Mathf.Round(_playerTransform.position.x) != Mathf.Round(_targetPoint.x))
        {
            _playerTransform.position = Vector2.MoveTowards(_playerTransform.position, _targetPoint, _forgeBurst * Time.deltaTime);
        yield return null;
        }      
            _isBurst = false;       
    }

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    public void Open()
    {
        throw new System.NotImplementedException();
    }
}
