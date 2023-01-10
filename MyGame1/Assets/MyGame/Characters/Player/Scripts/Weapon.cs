using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _offset;

    public void Aim(Vector2 mousePosition)
    {
        var mousePositionCam = _camera.ScreenToWorldPoint(mousePosition);
        Vector2 lookDirection = mousePositionCam - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - _offset;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
