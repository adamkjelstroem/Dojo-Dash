// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""db4c6d2e-190e-4ab6-87aa-1b97ca32d0b5"",
            ""actions"": [
                {
                    ""name"": ""MovementP1"",
                    ""id"": ""7e1d78d6-36b8-49d1-9964-bcf6544b22a1"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""DashChargeP1"",
                    ""id"": ""91b4fd7e-86d9-4bd2-b774-b683195f78c3"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d4350787-69e5-4a76-aa21-6c943b80dd1d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aea1c0a6-0901-4177-ad2b-1999378111d0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aeda5c96-6273-4211-a12b-f732a1eaf69d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6c303e81-31fa-4336-a2ed-5867fe5c3f65"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""227b311f-8e92-460e-a71e-1f26f8f6b3f4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""8ead8ea9-5287-4a9d-a6c7-c4fdfa8c13bd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1c4cba7b-39b4-4c18-9b69-3866a1760f07"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f4c04222-6c33-424f-8f96-0f3a36b29ee5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""855b1a0d-0439-4b65-8a0e-fe2c9dc38c25"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a23816e2-589a-4259-a61e-c4270ccaba06"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""2151cb48-e18f-4c87-a473-788eb247db42"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashChargeP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""b21e83b8-b89e-4643-aa6b-a33af6e090e2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashChargeP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""30063e32-f28e-4507-914d-1589dec7f9f1"",
            ""actions"": [
                {
                    ""name"": ""MovementP2"",
                    ""id"": ""70aa9c57-c536-4a7f-9546-df80768afb8c"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""DashChargeP2"",
                    ""id"": ""12ff28f1-1acb-4e10-9c6d-783c84642c55"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ccc69057-0ddc-4256-8199-a41c657d8e80"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5f0eb6c9-83c3-48aa-8cd2-e073dead068b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""360dae95-1cfc-4aac-8175-c29a35d3c5da"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e08bd772-f238-42cc-80fc-ea061b6d224d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7391245a-d166-48e0-960c-1f40329d74f4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""61ec0fd2-06d5-4f39-8f5b-0c5892e6fba7"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashChargeP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""basedOn"": """",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": []
        }
    ]
}");
        // Player1
        m_Player1 = asset.GetActionMap("Player1");
        m_Player1_MovementP1 = m_Player1.GetAction("MovementP1");
        m_Player1_DashChargeP1 = m_Player1.GetAction("DashChargeP1");
        // Player2
        m_Player2 = asset.GetActionMap("Player2");
        m_Player2_MovementP2 = m_Player2.GetAction("MovementP2");
        m_Player2_DashChargeP2 = m_Player2.GetAction("DashChargeP2");
    }
    ~PlayerControls()
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
    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }
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
    // Player1
    private InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private InputAction m_Player1_MovementP1;
    private InputAction m_Player1_DashChargeP1;
    public struct Player1Actions
    {
        private PlayerControls m_Wrapper;
        public Player1Actions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementP1 { get { return m_Wrapper.m_Player1_MovementP1; } }
        public InputAction @DashChargeP1 { get { return m_Wrapper.m_Player1_DashChargeP1; } }
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                MovementP1.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementP1;
                MovementP1.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementP1;
                MovementP1.cancelled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementP1;
                DashChargeP1.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashChargeP1;
                DashChargeP1.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashChargeP1;
                DashChargeP1.cancelled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDashChargeP1;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                MovementP1.started += instance.OnMovementP1;
                MovementP1.performed += instance.OnMovementP1;
                MovementP1.cancelled += instance.OnMovementP1;
                DashChargeP1.started += instance.OnDashChargeP1;
                DashChargeP1.performed += instance.OnDashChargeP1;
                DashChargeP1.cancelled += instance.OnDashChargeP1;
            }
        }
    }
    public Player1Actions @Player1
    {
        get
        {
            return new Player1Actions(this);
        }
    }
    // Player2
    private InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private InputAction m_Player2_MovementP2;
    private InputAction m_Player2_DashChargeP2;
    public struct Player2Actions
    {
        private PlayerControls m_Wrapper;
        public Player2Actions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementP2 { get { return m_Wrapper.m_Player2_MovementP2; } }
        public InputAction @DashChargeP2 { get { return m_Wrapper.m_Player2_DashChargeP2; } }
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                MovementP2.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementP2;
                MovementP2.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementP2;
                MovementP2.cancelled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementP2;
                DashChargeP2.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDashChargeP2;
                DashChargeP2.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDashChargeP2;
                DashChargeP2.cancelled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDashChargeP2;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                MovementP2.started += instance.OnMovementP2;
                MovementP2.performed += instance.OnMovementP2;
                MovementP2.cancelled += instance.OnMovementP2;
                DashChargeP2.started += instance.OnDashChargeP2;
                DashChargeP2.performed += instance.OnDashChargeP2;
                DashChargeP2.cancelled += instance.OnDashChargeP2;
            }
        }
    }
    public Player2Actions @Player2
    {
        get
        {
            return new Player2Actions(this);
        }
    }
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.GetControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnMovementP1(InputAction.CallbackContext context);
        void OnDashChargeP1(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMovementP2(InputAction.CallbackContext context);
        void OnDashChargeP2(InputAction.CallbackContext context);
    }
}
