using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : Ability
{
    private StaminaCount _maxCout;
    private StaminaDelay _delay;
    private int _currentCount;
    private float _timer;

    public bool IsExist { get { return _currentCount > 0; } }

    public Stamina(DataBasePlayer dataBasePlayer, Rigidbody2D rb) : base(dataBasePlayer, rb){}

    public override void SetParameter()
    {
        _maxCout = (StaminaCount)DataBasePlayer.GetParameter(ParametersPlayer.StaminaCount);
        _delay = (StaminaDelay)DataBasePlayer.GetParameter(ParametersPlayer.StaminaDelay);
    }

    public IEnumerator Timer()
    {
        while(_currentCount < _maxCout.Value)
        {
            _timer += Time.deltaTime;

            if(_timer >= _delay.Value)
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
