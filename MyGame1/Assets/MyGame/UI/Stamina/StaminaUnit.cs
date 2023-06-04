using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUnit : MonoBehaviour
{
    [SerializeField] private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Null()
    {
        _image.fillAmount = 0;
    }

    public void Full()
    {
        _image.fillAmount = 1;
    }

    public void OnList()
    {
        Stamina.Load.AddListener(Load);
    }

    public void OnDis()
    {
        Stamina.Load.RemoveListener(Load);
    }

    public void Load(float maxValue, float currentValue)
    {
        _image.fillAmount = currentValue / maxValue;
        if (_image.fillAmount == 1)
            OnDis();
    }
}
