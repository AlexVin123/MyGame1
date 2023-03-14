using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private void OnEnable()
    {
        Player.ChaigedHealth.AddListener(ChaingeBar);
    }

    private void OnDisable()
    {
        Player.ChaigedHealth.RemoveListener(ChaingeBar);
    }

    public void ChaingeBar(float value,float maxValue)
    {
        _bar.fillAmount -= value / maxValue;
    }
}
