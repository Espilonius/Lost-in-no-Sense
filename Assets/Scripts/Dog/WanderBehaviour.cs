using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    private FollowPlayer fp;
    [SerializeField] float wanderRadius = 20f;
    [SerializeField] float wanderTimer = 6f;
    private float timer;
    [SerializeField] float minFollowDistance = 10f;

    NavMeshAgent navAgent;
    private Vector3 targetPosition;


    void Awake()
    {
        fp = GetComponent<FollowPlayer>();
        navAgent = GetComponent<NavMeshAgent>();
        fp.enabled = false;
        timer = wanderTimer;
    }

    private void Update()
    {
        if (PlayerIsMoving() && CheckDistance() >= minFollowDistance)
        {
            fp.enabled = true;
            Debug.Log("first if");


        }

        else if (!PlayerIsMoving())
        {
            fp.enabled = false;
            Debug.Log("esle if");

            if (navAgent.remainingDistance < 5f) // check if agent has reached its target position
            {

                Debug.Log("inside else if");
                targetPosition = RandomCircle(player.transform.position, wanderRadius); // set new target position
                navAgent.SetDestination(targetPosition); // move towards target position
            }
        }

    }

    private bool PlayerIsMoving()
    {
        return player.GetComponent<Rigidbody>().velocity.magnitude > 0;


    }

    float CheckDistance()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }


    // Generate a random position within a circle around the center

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = Random.Range(0f, 360f);
        Vector3 pos = center + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
        NavMeshHit hit;
        NavMesh.SamplePosition(pos, out hit, radius, NavMesh.AllAreas); // sample position on NavMesh
        return hit.position;
    }




}
