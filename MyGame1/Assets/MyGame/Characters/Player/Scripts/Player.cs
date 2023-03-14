using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Stamina))]
[RequireComponent(typeof(Burst))]
[RequireComponent(typeof(BurstDown))]
[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(MovementDirectionX))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IControllable
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _torso;
    [SerializeField] private Transform _leg;

    private DataBasePlayer _characterData;
    private MovementDirectionX _movementDirectionX;
    private Jump _jump;
    private BurstDown _down;
    private Burst _burst;
    private Stamina _stamina;
    private DefenitionCollisions _defenitionCollisions;
    private Health _health;
    private Weapon _weapon;

    public static UnityEvent<float,float> ChaigedHealth = new UnityEvent<float,float>();

    private void Update()
    {
        Debug.Log(_health.CurrentHealth);
    }

    public void Aim(Vector2 mousePosition)
    {
        Vector2 lookDirection = _camera.ScreenToWorldPoint(mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _torso.rotation = Quaternion.Euler(0, 0, angle);
        Flip(mousePosition);
    }

    public void Init()
    {
        _characterData.Chainge.AddListener(Init);
        _defenitionCollisions = GetComponent<DefenitionCollisions>();
        _movementDirectionX = GetComponent<MovementDirectionX>();
        _jump = GetComponent<Jump>();
        _burst = GetComponent<Burst>();
        _stamina = GetComponent<Stamina>();
        _down = GetComponent<BurstDown>();
        _health = GetComponent<Health>();
        _weapon = GetComponentInChildren<Weapon>();
        InitAbility();

    }

    private void InitAbility()
    {
        var abilityes = GetComponents<Ability>();
        Debug.Log(abilityes.Length);

        foreach (var ability in abilityes)
        {
            ability.Init(_characterData);
        }
    }

    public void SetDataBase(DataBasePlayer dataBasePlayer)
    {
        _characterData = dataBasePlayer;
    }

    public void Burst(float directionX)
    {
        if (_stamina.IsExist)
        {
            StartCoroutine(_burst.StartBurst(directionX));
            _stamina.Spend();
            Debug.Log("UUUU");
        }
    }

    public void Down()
    {
        if (_stamina.IsExist)
        {
            _down.StartDown();
            _stamina.Spend();
        }
    }

    public void Jump()
    {
        if (_defenitionCollisions.IsGround)
            _jump.StartJump();
    }

    public void Move(float directoinX)
    {
        _movementDirectionX.Move(directoinX);
    }

    public void Shoot()
    {
        _weapon.Shoot();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        Debug.Log(_health.CurrentHealth + " _______________________" + damage); 
        ChaigedHealth?.Invoke(damage,_characterData.MaxHealth);
        if(_health.IsDie)
        {
            Die();
        }
    }

    private void Die()
    {

    }

    private void Flip(Vector2 mousePosition)
    {
        Vector2 positionPlayer = _camera.WorldToScreenPoint(transform.position);
        if(positionPlayer.x > mousePosition.x)
        {
            _torso.localScale = new Vector2(1, -1);
            _leg.localScale = new Vector2(-1, 1);
        }
        else
        {
            _torso.localScale = new Vector2(1, 1);
            _leg.localScale = new Vector2(1, 1);
        }
    }
}
