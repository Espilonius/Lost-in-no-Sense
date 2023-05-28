using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    [SerializeField] public float Gravity;

    [SerializeField] public bool fixedDirection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityControl>())
        {
            other.GetComponent<GravityControl>().gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
