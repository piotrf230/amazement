//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""62cd0c67-6c9a-4ae7-842e-55bf83e564b8"",
            ""actions"": [
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""66ed6456-8e22-4fcf-8ae1-79a68dc2718c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""52ec23c8-e5b7-4800-89a0-1e203b8b10f8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""7562b5f9-c4bf-4c8f-adb3-e6bec4e50ca8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d1b53ad6-1e80-4801-a2f3-c9ab238ae9ed"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c06fb7b-d638-4c1a-b5e2-65f9e9a87a8c"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c971df09-d340-4b67-a83e-85665fd145ce"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MoveRect"",
            ""id"": ""110878db-f580-4e0c-82bd-1e41ccfc5283"",
            ""actions"": [
                {
                    ""name"": ""N"",
                    ""type"": ""Button"",
                    ""id"": ""c30008ea-35c8-4770-b7db-f1f0f7ed2107"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""78050f17-c7df-4a66-9e4e-d1ebb8d10105"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""dd3ab84d-f6da-4788-b144-fad9d87e37ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""6f1a638f-a469-40cf-965d-f3a604778674"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7905c152-9d65-4414-935a-3ba0de235ba4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""N"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5062c2f8-4352-41a2-95d9-4880c35f1e55"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79aeff76-66f1-4b79-965c-1daf79c940b5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b1bc75f-9ca3-482c-af38-2adbd438bd56"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MoveHex"",
            ""id"": ""1b357645-bdc8-4426-91d0-78da884d1f8e"",
            ""actions"": [
                {
                    ""name"": ""NE"",
                    ""type"": ""Button"",
                    ""id"": ""b1f18069-cab4-4cc0-bf69-974bf37ebaa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""61c4eb6d-8df1-4a9e-9c75-9d9010d890a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SE"",
                    ""type"": ""Button"",
                    ""id"": ""01400fab-f842-4498-b91c-e2692ad84041"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SW"",
                    ""type"": ""Button"",
                    ""id"": ""7495c3ba-1f15-4bc4-af30-98e041e26fd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""10381e49-7251-4612-9258-5ae1a925aba0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NW"",
                    ""type"": ""Button"",
                    ""id"": ""8677b5ee-5875-4814-8145-0f8d5d75f282"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""feacd011-20ad-43bf-8c75-c61e53f1a675"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""950d1898-6dfd-43ce-b402-125be53e40b1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c7a2c28-c4a7-4f1c-8fc0-b1b0429a4dbd"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3de340b-a82a-4a81-b22b-2c632f848266"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94f288cc-9d91-41e0-a5b6-b941c8b508d1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""003c5a9a-7913-4a98-a4eb-7e437e63cf5b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Enter = m_Menu.FindAction("Enter", throwIfNotFound: true);
        m_Menu_Scroll = m_Menu.FindAction("Scroll", throwIfNotFound: true);
        m_Menu_Exit = m_Menu.FindAction("Exit", throwIfNotFound: true);
        // MoveRect
        m_MoveRect = asset.FindActionMap("MoveRect", throwIfNotFound: true);
        m_MoveRect_N = m_MoveRect.FindAction("N", throwIfNotFound: true);
        m_MoveRect_E = m_MoveRect.FindAction("E", throwIfNotFound: true);
        m_MoveRect_S = m_MoveRect.FindAction("S", throwIfNotFound: true);
        m_MoveRect_W = m_MoveRect.FindAction("W", throwIfNotFound: true);
        // MoveHex
        m_MoveHex = asset.FindActionMap("MoveHex", throwIfNotFound: true);
        m_MoveHex_NE = m_MoveHex.FindAction("NE", throwIfNotFound: true);
        m_MoveHex_E = m_MoveHex.FindAction("E", throwIfNotFound: true);
        m_MoveHex_SE = m_MoveHex.FindAction("SE", throwIfNotFound: true);
        m_MoveHex_SW = m_MoveHex.FindAction("SW", throwIfNotFound: true);
        m_MoveHex_W = m_MoveHex.FindAction("W", throwIfNotFound: true);
        m_MoveHex_NW = m_MoveHex.FindAction("NW", throwIfNotFound: true);
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

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Enter;
    private readonly InputAction m_Menu_Scroll;
    private readonly InputAction m_Menu_Exit;
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Enter => m_Wrapper.m_Menu_Enter;
        public InputAction @Scroll => m_Wrapper.m_Menu_Scroll;
        public InputAction @Exit => m_Wrapper.m_Menu_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Enter.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnEnter;
                @Scroll.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnScroll;
                @Exit.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // MoveRect
    private readonly InputActionMap m_MoveRect;
    private IMoveRectActions m_MoveRectActionsCallbackInterface;
    private readonly InputAction m_MoveRect_N;
    private readonly InputAction m_MoveRect_E;
    private readonly InputAction m_MoveRect_S;
    private readonly InputAction m_MoveRect_W;
    public struct MoveRectActions
    {
        private @Controls m_Wrapper;
        public MoveRectActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @N => m_Wrapper.m_MoveRect_N;
        public InputAction @E => m_Wrapper.m_MoveRect_E;
        public InputAction @S => m_Wrapper.m_MoveRect_S;
        public InputAction @W => m_Wrapper.m_MoveRect_W;
        public InputActionMap Get() { return m_Wrapper.m_MoveRect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveRectActions set) { return set.Get(); }
        public void SetCallbacks(IMoveRectActions instance)
        {
            if (m_Wrapper.m_MoveRectActionsCallbackInterface != null)
            {
                @N.started -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnN;
                @N.performed -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnN;
                @N.canceled -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnN;
                @E.started -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnE;
                @S.started -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnS;
                @W.started -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_MoveRectActionsCallbackInterface.OnW;
            }
            m_Wrapper.m_MoveRectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @N.started += instance.OnN;
                @N.performed += instance.OnN;
                @N.canceled += instance.OnN;
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
            }
        }
    }
    public MoveRectActions @MoveRect => new MoveRectActions(this);

    // MoveHex
    private readonly InputActionMap m_MoveHex;
    private IMoveHexActions m_MoveHexActionsCallbackInterface;
    private readonly InputAction m_MoveHex_NE;
    private readonly InputAction m_MoveHex_E;
    private readonly InputAction m_MoveHex_SE;
    private readonly InputAction m_MoveHex_SW;
    private readonly InputAction m_MoveHex_W;
    private readonly InputAction m_MoveHex_NW;
    public struct MoveHexActions
    {
        private @Controls m_Wrapper;
        public MoveHexActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NE => m_Wrapper.m_MoveHex_NE;
        public InputAction @E => m_Wrapper.m_MoveHex_E;
        public InputAction @SE => m_Wrapper.m_MoveHex_SE;
        public InputAction @SW => m_Wrapper.m_MoveHex_SW;
        public InputAction @W => m_Wrapper.m_MoveHex_W;
        public InputAction @NW => m_Wrapper.m_MoveHex_NW;
        public InputActionMap Get() { return m_Wrapper.m_MoveHex; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveHexActions set) { return set.Get(); }
        public void SetCallbacks(IMoveHexActions instance)
        {
            if (m_Wrapper.m_MoveHexActionsCallbackInterface != null)
            {
                @NE.started -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnNE;
                @NE.performed -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnNE;
                @NE.canceled -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnNE;
                @E.started -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnE;
                @SE.started -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnSE;
                @SE.performed -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnSE;
                @SE.canceled -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnSE;
                @SW.started -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnSW;
                @SW.performed -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnSW;
                @SW.canceled -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnSW;
                @W.started -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnW;
                @NW.started -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnNW;
                @NW.performed -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnNW;
                @NW.canceled -= m_Wrapper.m_MoveHexActionsCallbackInterface.OnNW;
            }
            m_Wrapper.m_MoveHexActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NE.started += instance.OnNE;
                @NE.performed += instance.OnNE;
                @NE.canceled += instance.OnNE;
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
                @SE.started += instance.OnSE;
                @SE.performed += instance.OnSE;
                @SE.canceled += instance.OnSE;
                @SW.started += instance.OnSW;
                @SW.performed += instance.OnSW;
                @SW.canceled += instance.OnSW;
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
                @NW.started += instance.OnNW;
                @NW.performed += instance.OnNW;
                @NW.canceled += instance.OnNW;
            }
        }
    }
    public MoveHexActions @MoveHex => new MoveHexActions(this);
    public interface IMenuActions
    {
        void OnEnter(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
    public interface IMoveRectActions
    {
        void OnN(InputAction.CallbackContext context);
        void OnE(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnW(InputAction.CallbackContext context);
    }
    public interface IMoveHexActions
    {
        void OnNE(InputAction.CallbackContext context);
        void OnE(InputAction.CallbackContext context);
        void OnSE(InputAction.CallbackContext context);
        void OnSW(InputAction.CallbackContext context);
        void OnW(InputAction.CallbackContext context);
        void OnNW(InputAction.CallbackContext context);
    }
}
