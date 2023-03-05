using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _offset;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _damage;
    [SerializeField] private float _distanceShot;
    [SerializeField] private float _range;

    public void Aim(Vector2 mousePosition)
    {
        var mousePositionCam = _camera.ScreenToWorldPoint(mousePosition);
        Vector2 lookDirection = mousePositionCam - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - _offset;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public void Shoot()
    {
        _particleSystem.startLifetime = _distanceShot;
        var shape = _particleSystem.shape;
        shape.angle = _range;
        _particleSystem.Play();
    }
}
