using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerPlay : MonoBehaviour
{
    float walkingPitch;
    float jumpPitch;
    float landPitch;
    [SerializeField] AudioClip[] footstepsSounds;
    [SerializeField] AudioSource playerSound;

    [SerializeField] InputReader inputReader = default;
    //private bool isJumping = false;



    private void OnEnable()
    {
        inputReader.moveEvent += OnMove;
        //inputReader.jumpEvent += OnJump;
    }
    private void OnDisable()
    {
        inputReader.moveEvent -= OnMove;
        //inputReader.jumpEvent -= OnJump;

    }


/*    private void OnJump()
    {
        if (isJumping)
        {
            PlayJumpSound();
        }
    }

    public void PlayJumpSound()
    {
        throw new NotImplementedException();
    }*/

    private void OnMove(Vector3 value)
    {
        // Walk Sound
        if (value != Vector3.zero)
        {
            PlayFootSteps();
        }
        // Idle Sound
        else if (value == Vector3.zero)
        {
            return;

        }

    }

    public void PlayFootSteps()
    {
        // Make sure to not play index 0
        int footstepClip = Random.Range(1, footstepsSounds.Length);
        // Add new clip to audio source
        playerSound.clip = footstepsSounds[footstepClip];
        // Play footstep clip once
        playerSound.PlayOneShot(playerSound.clip);

        // Walk volume
        playerSound.pitch = walkingPitch;
        walkingPitch = Random.Range(.5f, 1.5f);

        // Prevent last played sound to be played again by placing it on index 0 in the array
        // Get index 0
        footstepsSounds[footstepClip] = footstepsSounds[0];
        // Place clip index 0
        footstepsSounds[0] = playerSound.clip;


    }
}
