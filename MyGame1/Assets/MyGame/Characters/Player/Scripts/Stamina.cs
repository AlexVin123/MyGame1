using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private float _recoveryTime;

    private int _currentCount;

    private float _timer;

    public bool IsExist { get { return _currentCount > 0; } }

    private void Awake()
    {
        _currentCount = _maxCount;
    }

    private void Update()
    {
        if (_currentCount != _maxCount)
        {
            Timer();
        }
    }

    private void Timer()
    {
        _timer += Time.deltaTime;

        if (_timer >= _recoveryTime)
        {
            _timer = 0;
            _currentCount++;
            Debug.Log(_currentCount);
        }
    }

    public void Spend()
    {
        if (_currentCount != 0)
            _currentCount--;
    }
}
