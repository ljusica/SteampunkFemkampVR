//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Script/HandMenu/XR Hand Menu.inputactions
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

public partial class @XRHandMenu : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @XRHandMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""XR Hand Menu"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""32f2129b-6ae3-431d-a308-34390ae9a16b"",
            ""actions"": [
                {
                    ""name"": ""Hand Menu"",
                    ""type"": ""Button"",
                    ""id"": ""f5d57636-dd83-4ec2-b632-c2fe4cdd8c42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""67801cb5-c89c-4ed1-9d37-0a307a86078f"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""HandAnimations"",
            ""id"": ""fd1ed561-881d-4dea-ae6e-fa3d6d413412"",
            ""actions"": [
                {
                    ""name"": ""GripRight"",
                    ""type"": ""Button"",
                    ""id"": ""f7e42a52-8223-4fa3-ad90-c95fc1c9c45c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PinchRight"",
                    ""type"": ""Button"",
                    ""id"": ""32741030-d5d6-49e9-b6a6-2683e2537ea9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GripLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ef6e9f7c-7732-4d5b-97f8-3c89c59eac12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PinchLeft"",
                    ""type"": ""Button"",
                    ""id"": ""6ac76105-10a7-4d52-b0bc-db3f12831bf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9adee04d-99df-42f5-8ede-7615e780792a"",
                    ""path"": ""<XRController>{RightHand}/gripButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GripRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4268f520-c7ed-48ab-87c6-d3815d2e108f"",
                    ""path"": ""<XRController>{RightHand}/triggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PinchRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b5a33da-3d6f-48d8-847d-bb6a821b654d"",
                    ""path"": ""<XRController>{LeftHand}/gripButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GripLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b66dac77-7924-4709-ba6c-fe9d54ec623c"",
                    ""path"": ""<XRController>{LeftHand}/triggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PinchLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_HandMenu = m_UI.FindAction("Hand Menu", throwIfNotFound: true);
        // HandAnimations
        m_HandAnimations = asset.FindActionMap("HandAnimations", throwIfNotFound: true);
        m_HandAnimations_GripRight = m_HandAnimations.FindAction("GripRight", throwIfNotFound: true);
        m_HandAnimations_PinchRight = m_HandAnimations.FindAction("PinchRight", throwIfNotFound: true);
        m_HandAnimations_GripLeft = m_HandAnimations.FindAction("GripLeft", throwIfNotFound: true);
        m_HandAnimations_PinchLeft = m_HandAnimations.FindAction("PinchLeft", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_HandMenu;
    public struct UIActions
    {
        private @XRHandMenu m_Wrapper;
        public UIActions(@XRHandMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @HandMenu => m_Wrapper.m_UI_HandMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @HandMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnHandMenu;
                @HandMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnHandMenu;
                @HandMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnHandMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HandMenu.started += instance.OnHandMenu;
                @HandMenu.performed += instance.OnHandMenu;
                @HandMenu.canceled += instance.OnHandMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // HandAnimations
    private readonly InputActionMap m_HandAnimations;
    private IHandAnimationsActions m_HandAnimationsActionsCallbackInterface;
    private readonly InputAction m_HandAnimations_GripRight;
    private readonly InputAction m_HandAnimations_PinchRight;
    private readonly InputAction m_HandAnimations_GripLeft;
    private readonly InputAction m_HandAnimations_PinchLeft;
    public struct HandAnimationsActions
    {
        private @XRHandMenu m_Wrapper;
        public HandAnimationsActions(@XRHandMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @GripRight => m_Wrapper.m_HandAnimations_GripRight;
        public InputAction @PinchRight => m_Wrapper.m_HandAnimations_PinchRight;
        public InputAction @GripLeft => m_Wrapper.m_HandAnimations_GripLeft;
        public InputAction @PinchLeft => m_Wrapper.m_HandAnimations_PinchLeft;
        public InputActionMap Get() { return m_Wrapper.m_HandAnimations; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HandAnimationsActions set) { return set.Get(); }
        public void SetCallbacks(IHandAnimationsActions instance)
        {
            if (m_Wrapper.m_HandAnimationsActionsCallbackInterface != null)
            {
                @GripRight.started -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnGripRight;
                @GripRight.performed -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnGripRight;
                @GripRight.canceled -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnGripRight;
                @PinchRight.started -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnPinchRight;
                @PinchRight.performed -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnPinchRight;
                @PinchRight.canceled -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnPinchRight;
                @GripLeft.started -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnGripLeft;
                @GripLeft.performed -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnGripLeft;
                @GripLeft.canceled -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnGripLeft;
                @PinchLeft.started -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnPinchLeft;
                @PinchLeft.performed -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnPinchLeft;
                @PinchLeft.canceled -= m_Wrapper.m_HandAnimationsActionsCallbackInterface.OnPinchLeft;
            }
            m_Wrapper.m_HandAnimationsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GripRight.started += instance.OnGripRight;
                @GripRight.performed += instance.OnGripRight;
                @GripRight.canceled += instance.OnGripRight;
                @PinchRight.started += instance.OnPinchRight;
                @PinchRight.performed += instance.OnPinchRight;
                @PinchRight.canceled += instance.OnPinchRight;
                @GripLeft.started += instance.OnGripLeft;
                @GripLeft.performed += instance.OnGripLeft;
                @GripLeft.canceled += instance.OnGripLeft;
                @PinchLeft.started += instance.OnPinchLeft;
                @PinchLeft.performed += instance.OnPinchLeft;
                @PinchLeft.canceled += instance.OnPinchLeft;
            }
        }
    }
    public HandAnimationsActions @HandAnimations => new HandAnimationsActions(this);
    public interface IUIActions
    {
        void OnHandMenu(InputAction.CallbackContext context);
    }
    public interface IHandAnimationsActions
    {
        void OnGripRight(InputAction.CallbackContext context);
        void OnPinchRight(InputAction.CallbackContext context);
        void OnGripLeft(InputAction.CallbackContext context);
        void OnPinchLeft(InputAction.CallbackContext context);
    }
}
