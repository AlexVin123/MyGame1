using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stamina:MonoBehaviour
{
    private int _maxCout;
    private float _delay;
    private int _currentCount;
    private float _timer;

    public static UnityEvent<float, float> Load = new UnityEvent<float, float>();
    public static UnityEvent<int> ChaigeCount = new UnityEvent<int>(); 

    public bool IsExist { get { return _currentCount > 0; } }

    public int MaxCout => _maxCout;

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

    public void Init(ICharacterParameters parameters)
    {
        if (parameters != null)
        {
            if (float.TryParse(parameters.GetValue(TypeParameter.DelayStamina), out float result))
                _delay = result;
            else
                throw new System.FormatException("Конвертация не возможна, измените параметер на float");

            if (int.TryParse(parameters.GetValue(TypeParameter.CountStamina), out int result2))
                _maxCout = result2;
            else
                throw new System.FormatException("Конвертация не возможна, измените параметер на int");
        }

        _currentCount = _maxCout;
        _timer = 0;
    }
}
