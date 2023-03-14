using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina:Ability
{
    private int _maxCout;
    private float _delay;
    private int _currentCount;
    private float _timer;

    public static UnityEvent<float, float> Load = new UnityEvent<float, float>();
    public static UnityEvent<int> ChaigeCount = new UnityEvent<int>(); 

    public bool IsExist { get { return _currentCount > 0; } }

    private void Update()
    {
        if (_currentCount < _maxCout)
        {
            _timer += Time.deltaTime;
            Load?.Invoke(_delay, _timer);

            if (_timer >= _delay)
            {
                _currentCount++;
                ChaigeCount?.Invoke(_currentCount);
                _timer = 0;
            }
        }
    }

    public void Spend()
    {
        if (_currentCount != 0)
        {
            _currentCount--;
            _timer = 0;
        }

        ChaigeCount?.Invoke(_currentCount);
    }

    public override void Init(DataBase dataPlayer)
    {
        _maxCout = int.Parse(dataPlayer.GetParameter(TypeParameter.CountStamina));
        _delay = float.Parse(dataPlayer.GetParameter(TypeParameter.DelayStamina));
        _currentCount = _maxCout;
        Debug.Log(_maxCout + "+111111111111111+" + _delay);
    }
}
