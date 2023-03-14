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
    [SerializeField] private GameObject _shotpoint;
    public void Shoot()
    {
        _particleSystem.startLifetime = _distanceShot;
        _particleSystem.collision.RemovePlane(transform);
        var shape = _particleSystem.shape;
        shape.angle = _range;
        _particleSystem.Play();
        CrateRays();
    }

    public void CrateRays()
    {
        for (int i = 0; i < 15; i++)
        {
            float x = _shotpoint.transform.localRotation.x + Random.Range(-_range, _range);
            float y = _shotpoint.transform.localRotation.y + Random.Range(-_range, _range);
            float z = _shotpoint.transform.localRotation.z + Random.Range(-_range, _range);

            _shotpoint.transform.localRotation = Quaternion.Euler(x, y, z);
            Vector3 forward = _shotpoint.transform.TransformDirection(Vector3.right);

            RaycastHit2D hit = Physics2D.Raycast(_shotpoint.transform.position, forward, (_distanceShot * 100f)/2);

            if (hit)
                if (hit.collider.TryGetComponent(out Enemy enemy))
                    enemy.TakeDamage(_damage);
        }
    }
}
