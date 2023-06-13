using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private float _offset;

    [SerializeField] private Transform _sender;

    public Vector2 SenderPosition => _sender.transform.position; 


    public void Init(Transform sender)
    {
        _sender = sender;
    }
    public void AimTarget(Vector2 target)
    {
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + _offset;
        _sender.rotation = Quaternion.Euler(0, 0, angle);
    }
}
