using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private Transform _sender;

    private Vector2 _lookDirection;

    public void AimTarget(Vector2 target)
    {
        _lookDirection = target - (Vector2)_sender.transform.position;
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg + _offset;
        _sender.rotation = Quaternion.Euler(0, 0, angle);
    }
}
