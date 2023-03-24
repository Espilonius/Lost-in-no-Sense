using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/InputReader", order = 1)]
public class InputReader : ScriptableObject, InputActions.IPlayerInputActions, InputActions.IUIActions
{
    public InputActions inputActions { get; private set; }
    public event UnityAction<Vector3> moveEvent;
    public event UnityAction jumpEvent;
    public event UnityAction<Vector2> mouseEvent;
    public event UnityAction<bool> sprintEvent;
    public event UnityAction leftMouseButtonEvent;
    public event UnityAction rightMouseButtonEvent;
    public event UnityAction escapeEvent;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new();
        }
        EnableGameplay();
    }

    private void OnDisable()
    {
        DisableGameplay();
    }

    private void DisableGameplay() => inputActions.PlayerInput.Disable();
    private void DisableUI() => inputActions.UI.Disable();

    public void EnableGameplay()
    {
        inputActions.PlayerInput.Enable();
        inputActions.PlayerInput.SetCallbacks(this);
        DisableUI();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void EnableUI()
    {
        inputActions.UI.Enable();
        inputActions.UI.SetCallbacks(this);
        DisableGameplay();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnJumping(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            jumpEvent?.Invoke();
        }
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        mouseEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector3>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            sprintEvent?.Invoke(context.ReadValue<float>() > 0);
        }
        
    }

    public void OnLeftMouseButton(InputAction.CallbackContext context)
    {
        leftMouseButtonEvent?.Invoke();
}

    public void OnRightMouseButton(InputAction.CallbackContext context)
    {
        rightMouseButtonEvent?.Invoke();
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            escapeEvent?.Invoke();
        }
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
    }

    public void OnClick(InputAction.CallbackContext context)
    {
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
    }
}
