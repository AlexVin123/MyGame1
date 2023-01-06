using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private IControllable _controllable;
    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _controllable = GetComponent<IControllable>();
        
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerMovement.Jump.performed += OnJump;
        _input.PlayerMovement.Burst.performed += OnBurst;
        _input.PlayerMovement.Down.performed += OnDown; ;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerMovement.Jump.performed -= OnJump;
        _input.PlayerMovement.Burst.performed -= OnBurst;
        _input.PlayerMovement.Down.performed -= OnDown;
    }

    private void FixedUpdate()
    {
        ReadMove();
    }

    private void OnDown(InputAction.CallbackContext obj)
    {
        _controllable.Down();
    }

    private void OnBurst(InputAction.CallbackContext obj)
    {
        _controllable.Burst();
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
        _controllable.Jump();
    }

    private void ReadMove()
    {
        float directionX = _input.PlayerMovement.MoveX.ReadValue<float>();
        _controllable.Move(directionX);
    }
}
