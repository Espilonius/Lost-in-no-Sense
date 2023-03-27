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

    [SerializeField] Rigidbody leftHandItem;
    [SerializeField] Rigidbody rightHandItem;

    [SerializeField] private Transform aimPos;
    [SerializeField] float range = 10f, lerpSpeed = 5f;

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

    private void Update()
    {
        CheckHands();
    }

    private void CheckHands()
    {
        //let the items fly towards hand position
        if (leftHandItem)
        {
            leftHandItem.MovePosition(Vector3.Lerp(leftHandItem.position, leftHandPosition.transform.position, Time.deltaTime * lerpSpeed));
        }
        if (rightHandItem)
        {
            rightHandItem.MovePosition(Vector3.Lerp(rightHandItem.position, rightHandPosition.transform.position, Time.deltaTime * lerpSpeed));
        }

    }

    private bool LeftHandOccupied()
    {
        return leftHandItem;
    }
    private bool RightHandOccupied()
    {
        return rightHandItem;
    }

    private void DropItem(Rigidbody rb)
    {
        rb.isKinematic = false;
        rb.GetComponent<PickupItem>().SwitchCollider();
    }
    private Rigidbody? DetectItem()
    {
        RaycastHit hit;
        Physics.Raycast(aimPos.position, aimPos.forward, out hit, range);
        if (hit.transform == null) return null;
        if (hit.transform.GetComponent<PickupItem>())
        {
            return hit.transform.GetComponent<Rigidbody>();
        }
        return null;
    }
    private void EnableItem(Rigidbody rb)
    {
        if (rb)
        {
            rb.isKinematic = true;
            rb.GetComponent<PickupItem>().SwitchCollider();
        }
    }

    //Event System
    private void OnLeftHandPickup()
    {
        if (!LeftHandOccupied())
        {
            //Pickup item
            leftHandItem = DetectItem();
            EnableItem(leftHandItem);            
        }        
        else
        {
            DropItem(leftHandItem);
            leftHandItem = null;
        }
    }

    private void OnRightHandPickup()
    {
        if (!RightHandOccupied())
        {
            //Pickup item
            rightHandItem = DetectItem();
            EnableItem(rightHandItem);                       
        }        
        else
        {
            DropItem(rightHandItem);
            rightHandItem = null;
        }
    }
}
