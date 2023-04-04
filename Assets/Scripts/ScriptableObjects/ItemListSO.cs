using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemList", menuName = "ItemList")]
public class ItemListSO : ScriptableObject
{
    [SerializeField] private List<GameObject> itemList = new List<GameObject>();

    public GameObject GetItem(string itemName)
    {
        foreach (GameObject go in itemList)
        {
            if (go.TryGetComponent(out ItemBase item))
            {
                if (item.GetName() == itemName)
                {
                    return Instantiate(go,Vector3.zero, Quaternion.identity);
                }
            }
        }
        return null;
    }
}
