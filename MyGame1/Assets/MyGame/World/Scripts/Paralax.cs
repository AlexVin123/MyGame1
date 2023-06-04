using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed = 0.1f;
    [SerializeField] private bool _verticalParalax;

    private Transform _followingTarget;
    private Vector3 _targetPreviosPosition;

    
    void Start()
    {
        if(_followingTarget == null)
            _followingTarget = Camera.main.transform;

        _targetPreviosPosition = _followingTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = _followingTarget.position - _targetPreviosPosition;

        if (_verticalParalax)
            delta.y = 0;

        _targetPreviosPosition = _followingTarget.position;

        transform.position += delta * _parallaxSpeed;
    }
}
