using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : Ability
{
    private int _maxCout;
    private float _delay;
    private int _currentCount;
    private float _timer;

    public bool IsExist { get { return _currentCount > 0; } }

    public Stamina(int maxCount, float delay, Rigidbody2D rb) : base(rb) 
    {
        _maxCout = maxCount;
        _currentCount = maxCount;
        _delay = delay;
    }

    public IEnumerator Timer()
    {
        while (_currentCount < _maxCout)
        {
            _timer += Time.deltaTime;

            if (_timer >= _delay)
            {
                _currentCount++;
                _timer = 0;
            }
            yield return null;
        }
    }

    public void Spend()
    {
        if (_currentCount != 0)
            _currentCount--;
    }
}
