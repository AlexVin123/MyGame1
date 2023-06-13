using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private IControllable _controllable;
    private PlayerInput _input;
    private Animator _animator;
    private int ParameterOnWalk = Animator.StringToHash("OnWalk");
    private bool _isActive { get; set; }

    public PlayerInput Input => _input;


    public void Init()
    {
        _input = new PlayerInput();
        _controllable = GetComponent<IControllable>();
        _animator = GetComponent<Animator>();
        _input.Enable();
        _input.PlayerController.Jump.performed += OnJump;
        _input.PlayerController.Burst.performed += OnBurst;
        _input.PlayerController.Down.performed += OnDown;
        _input.PlayerController.Shoot.performed += OnShoot;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        _input.PlayerController.Jump.performed -= OnJump;
        _input.PlayerController.Burst.performed -= OnBurst;
        _input.PlayerController.Down.performed -= OnDown;
        _input.PlayerController.Shoot.performed -= OnShoot;
        _input.Disable();
    }

    private void FixedUpdate()
    {
        if(_isActive)
        {
        ReadMove();
        ReadAim();
        }
    }

    public void OnOpenPanel()
    {
        _isActive = false;
    }

    public void OnClousedPanel()
    {
        _isActive = true;
    }

    private void OnDown(InputAction.CallbackContext obj)
    {
        if(_isActive)
        {
        _controllable.Down();
        }
    }

    private void OnBurst(InputAction.CallbackContext obj)
    {
        if(_isActive)
        {
        Vector2 direction = _input.PlayerController.MoveX.ReadValue<Vector2>();
        _controllable.Burst(direction);
        }
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if(_isActive)
        {
            _controllable.Jump();
        }
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        if(_isActive)
        {
        _controllable.Shoot();
        }
    }

    private void ReadAim()
    {
        Vector2 mousePos = _input.PlayerController.PositionMouse.ReadValue<Vector2>();
        _controllable.Aim(mousePos);
    }

    private void ReadMove()
    {
        Vector2 direction = _input.PlayerController.MoveX.ReadValue<Vector2>();
        _controllable.Move(direction);

        if(direction.x == 0)
        {
            _animator.SetBool(ParameterOnWalk, false);
        }
        else
        {
            _animator.SetBool(ParameterOnWalk, true);
        }
    }
}
