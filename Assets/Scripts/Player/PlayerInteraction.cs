using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] InputReader inputReader = default;
    [SerializeField] private StatsSO stats;

    [SerializeField] Transform leftHandPosition;
    [SerializeField] Transform rightHandPosition;

    [SerializeField] GameObject leftHandItem;
    [SerializeField] GameObject rightHandItem;

    [SerializeField] private Transform aimPos;
    [SerializeField] float range;

    private void OnEnable()
    {
        inputReader.leftMouseButtonEvent += OnLeftHandPickup;
        inputReader.rightMouseButtonEvent += OnRightHandPickup;
    }
    private void OnDisable()
    {
        inputReader.leftMouseButtonEvent -= OnLeftHandPickup;
        inputReader.rightMouseButtonEvent -= OnRightHandPickup;
    }

    //Event System
    private void OnLeftHandPickup()
    {
        if (leftHandItem != null)
        {
            //drop item
        }
        else
        {
            RaycastHit hit;
            Physics.Raycast(aimPos.position, aimPos.forward, out hit, range);
            if (hit.transform == null) return;
            if (hit.collider.GetComponent<PickupItem>())
            {
                //pickup item
            }
        }
    }

    private void OnRightHandPickup()
    {
        if (rightHandItem != null)
        {
            //drop item
        }
        else
        {

        }
    }
}
