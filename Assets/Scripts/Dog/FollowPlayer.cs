using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navAgent;
    [SerializeField] float stoppingDistance = 5f;


    // Start is called before the first frame update
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(target.position);
        navAgent.stoppingDistance = stoppingDistance;
    }


}
