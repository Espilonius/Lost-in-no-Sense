using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class DogFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] float followRadius = 5f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float wanderRadius = 5f;
    [SerializeField] float wanderTimer = 5f;
    [SerializeField] string targetTag = "Bone";
    [SerializeField] float companionDistance = 2f;
    [SerializeField] float followDistance = 1.5f;
    [SerializeField] float minFollowDistance = 1f;

    private Transform target;
    private float timer;


    private void Awake()
    {

    }


    private void Start()
    {

    }


    private void Update()
    {
        float distanceFromPlayer = GetDistanceFromPlayer();
        if (distanceFromPlayer > minFollowDistance)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        float newX = player.transform.position.x + followDistance;
        float newZ = player.transform.position.z + followDistance;
        float newY = transform.position.y;

        transform.position = new Vector3(newX, newY, newZ);
    }

    // Get the position of the Player Object & Dog Object
    // Check for distance between Dog and Player Object
    private float GetDistanceFromPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }






    // Rotate the Dog Object toward the Player Object
    // Check if player is in scene
    // Check if player moves around
    // If player moves around trigger dog follow
    // Change the position of the Dog to follow in a specific radius around the player object
    // If player doesn't move around trigger dog random move in a specific area. 

}
