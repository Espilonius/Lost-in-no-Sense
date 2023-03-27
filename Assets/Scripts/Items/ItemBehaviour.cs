using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    Dictionary<string, ItemBase> properties = new();
    void Awake()
    {
        GetDebugProperties();
    }
    private void GetDebugProperties()
    {
        properties = new Dictionary<string, ItemBase>();
        ItemBase[] debugs = gameObject.GetComponents<ItemBase>();
        foreach (ItemBase property in debugs)
        {
            properties.Add(property.GetName(), property);
        }
    }

    public string[] GetNames()
    {
        List<string> names = new();
        foreach (string name in properties.Keys)
        {
            names.Add(name);
        }
        return names.ToArray();
    }    
}
