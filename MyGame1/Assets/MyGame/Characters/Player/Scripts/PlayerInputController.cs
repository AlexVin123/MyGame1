using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(IControllable))]
public class PlayerInputController : MonoBehaviour
{
    private IControllable _controllable;
    private PlayerInput _input;
    private bool _isActive { get; set; }

    public PlayerInput Input => _input;

    public void Init()
    {
        _input = new PlayerInput();
        _controllable = GetComponent<IControllable>();
        _input.Enable();
        _input.PlayerController.Jump.performed += OnJump;
        _input.PlayerController.Burst.performed += OnBurst;
        _input.PlayerController.Down.performed += OnDown;
    }

    private void OnDisable()
    {
        _input.PlayerController.Jump.performed -= OnJump;
        _input.PlayerController.Burst.performed -= OnBurst;
        _input.PlayerController.Down.performed -= OnDown;
        _input.Disable();
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            ReadMove();
            ReadAim();
            ReedShoot();
        }
    }

    private void ReedShoot()
    {
        float Press = _input.PlayerController.ShootPress.ReadValue<float>();

        if (Press > 0)
            _controllable.Shoot();

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
        if (_isActive)
        {
            _controllable.Down();
        }
    }

    private void OnBurst(InputAction.CallbackContext obj)
    {
        if (_isActive)
        {
            Vector2 direction = _input.PlayerController.MoveX.ReadValue<Vector2>();
            _controllable.Burst(direction);
        }
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (_isActive)
        {
            _controllable.Jump();
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
    }
}
