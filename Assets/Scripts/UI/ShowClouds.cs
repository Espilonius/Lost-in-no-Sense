using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class ShowClouds : MonoBehaviour
{
    [SerializeField] List<GameObject> combineIdeaClouds = new List<GameObject>();

    [SerializeField] private CombineItems combineItems;

    private const int maxAllowedNames = 3;

    private void OnEnable()
    {
        combineItems.onCombined += ActivateClouds;
    }
    private void OnDisable()
    {
        combineItems.onCombined -= ActivateClouds;
    }

    public void ActivateClouds(string[] names)
    {
        DeActivateClouds();

        if (TotalExceeded(names.Length)) return;
        if (ContainsSingleName(names)) return;

        for (int i = 0; i < names.Length; i++)
        {
            SetCombineCloud(combineIdeaClouds[i], names[i]);
        }
    }

    private bool ContainsSingleName(string[] names)
    {
        if (names.Length == 1)
        {
            SetCombineCloud(combineIdeaClouds[2], names[0]);
            return true;
        }
        return false;
    }

    private bool TotalExceeded(int v)
    {
        if (v > maxAllowedNames)
        {
            Debug.Log("Item has more than 3 stuff", this);
            return true;
        }
        return false;
    }

    private void SetCombineCloud(GameObject cloud, string itemText)
    {
        cloud.GetComponentInChildren<TMP_Text>().text = itemText;
        cloud.SetActive(true);
    }

    public void DeActivateClouds()
    {
        foreach (GameObject combineCloud in combineIdeaClouds)
        {
            combineCloud.SetActive(false);
        }
    }
}
