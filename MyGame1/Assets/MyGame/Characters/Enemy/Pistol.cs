using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _countBulletInPool;
    static private PoolMono<Bullet> _pool;
    [SerializeField] private float _speedShoot = 1;

    private Timer _timer = new Timer(TypeTimer.UpdateTick);

    private bool _isTryShot = true;

    private void OnEnable()
    {
        _timer.OnTimerFinishedEvent += TryShot;
    }

    private void OnDisable()
    {
        _timer.OnTimerFinishedEvent -= TryShot;
    }



    public override void Init(ICharacterConfig parameters)
    {
        if(_pool == null)
        {
        _pool = new PoolMono<Bullet>(_prefab, _countBulletInPool);
        _pool.autoExpand = true;
        }
    }

    public override void Shoot()
    {
        if(_isTryShot)
        {
        Bullet temp = _pool.GetFreeElement(Shotpoint.position,Shotpoint.transform.rotation);
            _isTryShot = false;
            _timer.Start(_speedShoot);
        }
    }

    private void TryShot()
    {
        _isTryShot = true;
    }
}
