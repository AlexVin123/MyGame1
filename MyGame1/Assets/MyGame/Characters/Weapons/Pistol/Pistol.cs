using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _countBulletInPool;
    [SerializeField] private float _speedShoot = 1;
    [SerializeField] private AudioSource _shotSound;

    static private PoolMono<Bullet> _pool;
    private Timer _timer = new Timer(TypeTimer.UpdateTick);

    private bool _isTryShot = true;

    private void OnEnable()
    {
        _timer.TimerFinished += TryShot;
    }

    private void OnDisable()
    {
        _timer.TimerFinished -= TryShot;
    }



    public override void Init(ICharacterConfig parameters)
    {
        if (_pool == null)
        {
            _pool = new PoolMono<Bullet>(_prefab, _countBulletInPool);
            _pool.AutoExpand = true;
        }
    }

    public override void Shoot()
    {
        if (_isTryShot)
        {
            _shotSound.Play();
            _pool.GetFreeElement(Shotpoint.position, Shotpoint.transform.rotation);
            _isTryShot = false;
            _timer.Start(_speedShoot);
        }
    }

    private void TryShot()
    {
        _isTryShot = true;
    }
}
