//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/MyGame/Characters/Player/Scripts/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerController"",
            ""id"": ""37db2c94-ddcd-4ba1-b00e-82da92deeef3"",
            ""actions"": [
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Value"",
                    ""id"": ""4e0a9f23-7d56-401f-9cdd-1090f672a8dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b0755e7a-1125-4153-a736-84872ff13c5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Burst"",
                    ""type"": ""Button"",
                    ""id"": ""3134abf7-1cae-4fea-b97c-e33914f87e14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""1e6da260-5587-4d72-b4ab-d76855ff9c5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PositionMouse"",
                    ""type"": ""Value"",
                    ""id"": ""88bcd247-782a-4f25-9c6a-d27e844c4438"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""85573970-2718-47f7-89c5-303457034f4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Value"",
                    ""id"": ""1ed3fff1-0b11-4c8c-8ce9-554c63bf87a6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShootPress"",
                    ""type"": ""Button"",
                    ""id"": ""a2af251a-662a-4022-9993-b1c913cbac63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""15ac8cd3-16f7-4347-b070-a029a1d36869"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""4472cc60-38aa-4c6a-985d-6d9e9c52cce7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""456a3ad7-68b2-430e-9274-19f4d0a2fef2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dab7a703-4290-4a81-968c-136830ed3401"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8397274e-5080-4434-bde4-cabc7da8d743"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cadaf914-33aa-41e9-80f2-0dd34dcf6a1c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d71781d9-44f3-4a32-ab08-138cfe8fc3c6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PositionMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1569f01f-b21e-4fad-af8e-9843d3d50db7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4311aa25-7ea4-4921-ae5f-5a6d6444a353"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61117057-d6a7-435d-bf34-dd7c095425e6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerController
        m_PlayerController = asset.FindActionMap("PlayerController", throwIfNotFound: true);
        m_PlayerController_MoveX = m_PlayerController.FindAction("MoveX", throwIfNotFound: true);
        m_PlayerController_Jump = m_PlayerController.FindAction("Jump", throwIfNotFound: true);
        m_PlayerController_Burst = m_PlayerController.FindAction("Burst", throwIfNotFound: true);
        m_PlayerController_Down = m_PlayerController.FindAction("Down", throwIfNotFound: true);
        m_PlayerController_PositionMouse = m_PlayerController.FindAction("PositionMouse", throwIfNotFound: true);
        m_PlayerController_Shoot = m_PlayerController.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerController_OpenMenu = m_PlayerController.FindAction("OpenMenu", throwIfNotFound: true);
        m_PlayerController_ShootPress = m_PlayerController.FindAction("ShootPress", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerController
    private readonly InputActionMap m_PlayerController;
    private List<IPlayerControllerActions> m_PlayerControllerActionsCallbackInterfaces = new List<IPlayerControllerActions>();
    private readonly InputAction m_PlayerController_MoveX;
    private readonly InputAction m_PlayerController_Jump;
    private readonly InputAction m_PlayerController_Burst;
    private readonly InputAction m_PlayerController_Down;
    private readonly InputAction m_PlayerController_PositionMouse;
    private readonly InputAction m_PlayerController_Shoot;
    private readonly InputAction m_PlayerController_OpenMenu;
    private readonly InputAction m_PlayerController_ShootPress;
    public struct PlayerControllerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveX => m_Wrapper.m_PlayerController_MoveX;
        public InputAction @Jump => m_Wrapper.m_PlayerController_Jump;
        public InputAction @Burst => m_Wrapper.m_PlayerController_Burst;
        public InputAction @Down => m_Wrapper.m_PlayerController_Down;
        public InputAction @PositionMouse => m_Wrapper.m_PlayerController_PositionMouse;
        public InputAction @Shoot => m_Wrapper.m_PlayerController_Shoot;
        public InputAction @OpenMenu => m_Wrapper.m_PlayerController_OpenMenu;
        public InputAction @ShootPress => m_Wrapper.m_PlayerController_ShootPress;
        public InputActionMap Get() { return m_Wrapper.m_PlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Add(instance);
            @MoveX.started += instance.OnMoveX;
            @MoveX.performed += instance.OnMoveX;
            @MoveX.canceled += instance.OnMoveX;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Burst.started += instance.OnBurst;
            @Burst.performed += instance.OnBurst;
            @Burst.canceled += instance.OnBurst;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
            @PositionMouse.started += instance.OnPositionMouse;
            @PositionMouse.performed += instance.OnPositionMouse;
            @PositionMouse.canceled += instance.OnPositionMouse;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @OpenMenu.started += instance.OnOpenMenu;
            @OpenMenu.performed += instance.OnOpenMenu;
            @OpenMenu.canceled += instance.OnOpenMenu;
            @ShootPress.started += instance.OnShootPress;
            @ShootPress.performed += instance.OnShootPress;
            @ShootPress.canceled += instance.OnShootPress;
        }

        private void UnregisterCallbacks(IPlayerControllerActions instance)
        {
            @MoveX.started -= instance.OnMoveX;
            @MoveX.performed -= instance.OnMoveX;
            @MoveX.canceled -= instance.OnMoveX;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Burst.started -= instance.OnBurst;
            @Burst.performed -= instance.OnBurst;
            @Burst.canceled -= instance.OnBurst;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
            @PositionMouse.started -= instance.OnPositionMouse;
            @PositionMouse.performed -= instance.OnPositionMouse;
            @PositionMouse.canceled -= instance.OnPositionMouse;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @OpenMenu.started -= instance.OnOpenMenu;
            @OpenMenu.performed -= instance.OnOpenMenu;
            @OpenMenu.canceled -= instance.OnOpenMenu;
            @ShootPress.started -= instance.OnShootPress;
            @ShootPress.performed -= instance.OnShootPress;
            @ShootPress.canceled -= instance.OnShootPress;
        }

        public void RemoveCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControllerActions @PlayerController => new PlayerControllerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerControllerActions
    {
        void OnMoveX(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnPositionMouse(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnShootPress(InputAction.CallbackContext context);
    }
}
