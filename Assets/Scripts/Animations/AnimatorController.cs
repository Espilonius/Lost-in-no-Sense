using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimatorController : MonoBehaviour
{
    float movementSpeed;
    [SerializeField] InputReader inputReader = default;
    [SerializeField] private StatsSO stats;
    [SerializeField] Animator animator;
    private Vector3 position = new Vector3();
    private void OnEnable()
    {
        inputReader.moveEvent += OnMove;
    }
    private void OnDisable()
    {
        inputReader.moveEvent -= OnMove;
    }

    // Other Animations who need key input
    // Running animation
    // float runningSpeed = 1f;
    // if(movement speed > walking speed){
    //      animator.SetFloat("speed", runningSpeed);
    //   }
    // else if(on keyup spacebar){
    //      animator.SetFloat("speed", runningSpeed);
    //   }

    // Jumping animation

    // if(on keydown spacebar){
    //      animator.SetBool("isJumping", true);
    //   }
    // else if(on keyup spacebar){ 
    //      animator.SetBool("isJumping", false);
    //   }



    // Movement animation
    private void OnMove(Vector3 value)
    {
        // Walk Animation
        if (value != Vector3.zero)
        {
            animator.SetFloat("speed", 0.02f);
        }
        // Idle Animation
        else if (value == Vector3.zero)
        {
            animator.SetFloat("speed", 0f);
        }

    }
}
