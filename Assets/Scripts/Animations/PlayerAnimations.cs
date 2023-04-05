using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerAnimations : MonoBehaviour
{
    float movementSpeed;
    [SerializeField] InputReader inputReader = default;
    [SerializeField] Animator playerAnimator;
    private bool isJumping = false;
    private void OnEnable()
    {
        inputReader.moveEvent += OnMove;
        inputReader.jumpEvent += OnJump;
    }
    private void OnDisable()
    {
        inputReader.moveEvent -= OnMove;
        inputReader.jumpEvent -= OnJump;

    }


    private void OnJump()
    {
        if (!isJumping)
        {
            isJumping = true;
            playerAnimator.SetBool("jump", true);
            StartCoroutine(ResetJumpAnimation());
        }
    }
    IEnumerator ResetJumpAnimation()
    {
        // Wait for the jump animation to finish playing
        yield return new WaitForSeconds(.3f);

        // Reset jump animation and set isJumping to false
        playerAnimator.SetBool("jump", false);
        isJumping = false;
    }
    // Movement animation


    private void OnMove(Vector3 value)
    {
        // Walk Animation
        if (value != Vector3.zero)
        {
            playerAnimator.SetFloat("speed", 0.02f);
        }
        // Idle Animation
        else if (value == Vector3.zero)
        {
            playerAnimator.SetFloat("speed", 0f);
        }

    }
}
