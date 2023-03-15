using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/InputReader", order = 1)]
public class InputReader : ScriptableObject, InputActions.IPlayerInputActions
{
    public InputActions inputActions;
    public event UnityAction<Vector3> moveEvent;
    public event UnityAction jumpEvent;
    public event UnityAction attack;
    public event UnityAction<Vector2> mouseEvent;
    public event UnityAction<bool> sprintEvent;


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

    private void DisableGameplay()
    {
        inputActions.PlayerInput.Disable();
    }

    public void EnableGameplay()
    {
        inputActions.PlayerInput.Enable();
        inputActions.PlayerInput.SetCallbacks(this);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
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
}
