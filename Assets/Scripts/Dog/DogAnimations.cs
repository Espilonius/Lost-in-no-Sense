using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DogAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector3 lastPos;
    void Update()
    {
        // Walk Animation
        if (IsMoving())
        {
            lastPos = transform.position;
            animator.SetBool("isWalking", true);
        }
        // Idle Animation
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private bool IsMoving()
    {
        return transform.position != lastPos;
    }


}
