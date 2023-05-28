using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject targetItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject == player) return;
        if (player.GetComponent<PlayerInteraction>().HasCombinedItem())
        {
            this.gameObject.SetActive(false);
        }        
    }
}
