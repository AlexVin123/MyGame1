using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private float _range;
    [SerializeField] private ContactFilter2D _filter;
    [SerializeField] private float Forge;
    [SerializeField] private ParticleSystem[] _particleSystem;
    [SerializeField] private float _distanceShot;
    [SerializeField] private float _damage;
    [SerializeField] private float _reload;

    private bool _isTryShot;
    private bool _isInit = false;

    private Timer _timer = new Timer(TypeTimer.UpdateTick);


    private RaycastHit2D[] _hits = new RaycastHit2D[1];

    public override void Init(ICharacterConfig parameters)
    {
        if (_isInit)
            _timer.OnTimerFinishedEvent -= TryShot;

        if (parameters != null)
        {

            if (int.TryParse(parameters.GetValue(TypeParameter.DistanceShot), out int result))
                _distanceShot = result;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на int");

            if (int.TryParse(parameters.GetValue(TypeParameter.Damage), out int result2))
                _damage = result2;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на int");

            if (int.TryParse(parameters.GetValue(TypeParameter.RangeShotGun), out int result3))
                _range = result3;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на int");

            if (float.TryParse(parameters.GetValue(TypeParameter.Reload), out float result4))
                _reload = result4;
            else
                throw new System.ArgumentException("Конвертация невозможна, поменяйте данные на int");
        }

         var temp  = _particleSystem[0].shape;
        temp.angle = _range;
        _particleSystem[0].startLifetime = _distanceShot/36;
        _isTryShot = true;
        _isInit = true;
        _timer.OnTimerFinishedEvent += TryShot;
    }

    private void OnEnable()
    {
        _timer.OnTimerFinishedEvent -= TryShot;
    }

    public override void Shoot()
    {
        if( _isTryShot)
        {
            foreach (var hit in _particleSystem)
            {
                hit.Play();
            }
            CrateRays();
            _isTryShot = false;
            _timer.Start(_reload);
        }
    }

    private void TryShot()
    {
        _isTryShot = true;
    }

    private void CrateRays()
    {
        for (int i = 0; i < 15; i++)
        {
            float z = Shotpoint.localRotation.z + Random.Range(-_range, _range);
            Shotpoint.transform.localRotation = Quaternion.identity;
            Shotpoint.transform.localRotation = Quaternion.Euler(Shotpoint.localRotation.x, Shotpoint.localRotation.y, z);
            Vector3 forward = Shotpoint.transform.TransformDirection(Vector3.right);
            Physics2D.Raycast(Shotpoint.position, forward, _filter, results: _hits, distance: _distanceShot);
            Vector3 distance = forward * _distanceShot;

           Debug.DrawRay(Shotpoint.position, distance, Color.yellow, 4);

            if (_hits[0] && _hits[0].collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                _hits[0].collider.attachedRigidbody.AddForce(forward * Forge, ForceMode2D.Impulse);
            }

            _hits = new RaycastHit2D[1];
        }
    }
}
