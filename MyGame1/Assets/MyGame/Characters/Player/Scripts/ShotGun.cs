using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private float _range;
    [SerializeField] private ContactFilter2D _filter;

    private RaycastHit2D[] _hits = new RaycastHit2D[1];

    public override void Shoot()
    {
        CrateRays();
    }

    private void CrateRays()
    {
        for (int i = 0; i < 15; i++)
        {
            float z = Shotpoint.localRotation.z + Random.Range(-_range, _range);
            Shotpoint.transform.localRotation = Quaternion.identity;
            Shotpoint.transform.localRotation = Quaternion.Euler(Shotpoint.localRotation.x, Shotpoint.localRotation.y, z);
            Vector3 forward = Shotpoint.transform.TransformDirection(Vector3.right);
            Physics2D.Raycast(Shotpoint.position, forward, _filter, results: _hits, distance: DistanceShot);
            Vector3 distance = forward * DistanceShot;

            Debug.DrawRay(Shotpoint.position, distance, Color.yellow, 4);
            Debug.Log(_hits[0].collider); 

            if (_hits[0] && _hits[0].collider.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(Damage);

            _hits = new RaycastHit2D[1];
        }
    }
}
