using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] InputReader inputReader = default;
    [SerializeField] private StatsSO stats;
    [SerializeField] private CombineItems combineItems;

    [SerializeField] Transform leftHandPosition;
    [SerializeField] Transform rightHandPosition;

    [SerializeField] Rigidbody leftHandItem = null;
    [SerializeField] Rigidbody rightHandItem = null;
    [SerializeField] ItemBase dummyItem;
    private Rigidbody stashedLeftHandItem = null;
    private Rigidbody stashedRightHandItem = null;
    private bool hasCombinedItem = false;

    [SerializeField] private Transform aimPos;
    [SerializeField] float range = 10f, lerpSpeed = 5f;

    private CombineMode combineMode;

    private void OnEnable()
    {
        inputReader.leftMouseButtonEvent += OnLeftHandEvent;
        inputReader.rightMouseButtonEvent += OnRightHandEvent;
        combineItems.onCombineChoice += CombinedItem;
    }
    private void OnDisable()
    {
        inputReader.leftMouseButtonEvent -= OnLeftHandEvent;
        inputReader.rightMouseButtonEvent -= OnRightHandEvent;
        combineItems.onCombineChoice -= CombinedItem;
    }

    private void Update()
    {
        CheckHands();
    }

    public ItemBase GetLeftHandItem()
    {
        if (leftHandItem == null)
        {
            return dummyItem; 
        }
        return leftHandItem.GetComponent<ItemBase>();
    }
    public ItemBase GetRightHandItem()
    {
        if (leftHandItem == null)
        {
            return dummyItem;
        }
        return rightHandItem.GetComponent<ItemBase>();
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

    private void DropLeftHandItem()
    {
        DropItem(leftHandItem);
        leftHandItem = null;
    }
    private void DropRightHandItem()
    {                
        if (!hasCombinedItem)
        {
            DropItem(rightHandItem);
            rightHandItem = null;
        }
        if (hasCombinedItem)
        {
            Destroy(rightHandItem.gameObject);
            UnStashCombineBaseItems();
            hasCombinedItem = false;
        }
    }
    private void StashCombineBaseItems()
    {
        stashedLeftHandItem = leftHandItem;
        stashedLeftHandItem.gameObject.SetActive(false);
        leftHandItem = null;

        stashedRightHandItem = rightHandItem;
        stashedRightHandItem.gameObject.SetActive(false);
        rightHandItem = null;
    }
    private void UnStashCombineBaseItems()
    {
        leftHandItem = stashedLeftHandItem;
        leftHandItem.transform.position = leftHandPosition.position;
        leftHandItem.gameObject.SetActive(true);
        stashedLeftHandItem = null;

        rightHandItem = stashedRightHandItem;
        rightHandItem.transform.position = rightHandPosition.position;
        rightHandItem.gameObject.SetActive(true);
        stashedRightHandItem = null;
    }
    private void EquipCombinedItem(GameObject combinedItem)
    {
        rightHandItem = combinedItem.GetComponent<Rigidbody>();
        EnableItem(rightHandItem);
        rightHandItem.transform.position = rightHandPosition.transform.position;
        hasCombinedItem = true;
    }


    private void LeftHandPickup()
    {
        if (!LeftHandOccupied())
        {
            if (hasCombinedItem) return;
            //Pickup item
            leftHandItem = DetectItem();
            EnableItem(leftHandItem);
        }
        else
        {
            DropLeftHandItem();
        }
    }
    private void RightHandPickUp()
    {
        if (!RightHandOccupied())
        {
            if (hasCombinedItem) return;
            //Pickup item
            rightHandItem = DetectItem();
            EnableItem(rightHandItem);
        }
        else
        {
            DropRightHandItem();
        }
    }

    //Event System
    private void OnLeftHandEvent()
    {
        LeftHandPickup();
    }

    private void OnRightHandEvent()
    {
        RightHandPickUp();
    }

    private void CombinedItem(GameObject item)
    {
        StashCombineBaseItems();
        EquipCombinedItem(item);
    }
}
