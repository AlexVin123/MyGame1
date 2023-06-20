using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    public void ChaingeBar(float value,float maxValue)
    {
        _bar.fillAmount = value / maxValue;
    }
}
