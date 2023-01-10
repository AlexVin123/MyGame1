using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Menu _menu;

    private IControllable _controllable;
    private PlayerInput _input;
    private DefenitionCollisions _defenitionCollisions;

    private void Awake()
    {
        _defenitionCollisions = GetComponent<DefenitionCollisions>();
        _input = new PlayerInput();
        _controllable = GetComponent<IControllable>();

    }

    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerController.Jump.performed += OnJump;
        _input.PlayerController.Burst.performed += OnBurst;
        _input.PlayerController.Down.performed += OnDown;
        _input.PlayerController.Update.performed += OnOpenMenu;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerController.Jump.performed -= OnJump;
        _input.PlayerController.Burst.performed -= OnBurst;
        _input.PlayerController.Down.performed -= OnDown;
        _input.PlayerController.Update.performed -= OnOpenMenu;
    }

    private void FixedUpdate()
    {
        ReadMove();
        ReadAim();
    }

    private void OnOpenMenu(InputAction.CallbackContext obj)
    {
        _menu.OpenClouse();
    }

    private void OnDown(InputAction.CallbackContext obj)
    {
        _controllable.Down();
    }

    private void OnBurst(InputAction.CallbackContext obj)
    {
        float directionX = _input.PlayerController.MoveX.ReadValue<float>();
        _controllable.Burst(directionX);
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (_defenitionCollisions.IsGround)
            _controllable.Jump();
    }

    private void ReadAim()
    {
        Vector2 mousePos = _input.PlayerController.PositionMouse.ReadValue<Vector2>();
        _weapon.Aim(mousePos);
    }

    private void ReadMove()
    {
        float directionX = _input.PlayerController.MoveX.ReadValue<float>();
        _controllable.Move(directionX);
    }
}
