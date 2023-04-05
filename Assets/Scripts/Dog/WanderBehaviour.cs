using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float wanderRadius = 5f;
    [SerializeField] float wanderTimer = 6f;
    [SerializeField] float timer;
    [SerializeField] float maxDistance = 20f;

    NavMeshAgent navAgent;
    bool isWandering;


    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        GetComponent<FollowPlayer>().enabled = false;

        timer = wanderTimer;
    }

    private void Update()
    {

        if (PlayerIsMoving() && CheckDistance() >= maxDistance)
        {
            GetComponent<FollowPlayer>().enabled = true;
        }
        else {
            GetComponent<FollowPlayer>().enabled = false;

        }



    }

    private bool PlayerIsMoving()
    {
        if (target.GetComponent<Rigidbody>().velocity.magnitude > 0)
        {

            return true;

        }
        else { return false; }
        
    }

    float CheckDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
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
