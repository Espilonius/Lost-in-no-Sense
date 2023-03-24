using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PickupItem : MonoBehaviour
{
    [SerializeField] Collider colliderCom;
    public void SwitchCollider()
    {
        colliderCom.enabled = !colliderCom.enabled;
    }
}
