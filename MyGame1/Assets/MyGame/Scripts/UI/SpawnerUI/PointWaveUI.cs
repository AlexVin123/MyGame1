using UnityEngine;
using UnityEngine.UI;

public class PointWaveUI : MonoBehaviour
{
    [SerializeField] private Image _imageActivePoint;

    public bool IsActivePoint { get { return _imageActivePoint.enabled; } set { _imageActivePoint.enabled = value; } }
}
