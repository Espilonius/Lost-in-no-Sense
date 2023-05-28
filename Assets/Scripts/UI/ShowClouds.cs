using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class ShowClouds : MonoBehaviour
{
    [SerializeField] List<GameObject> combineCloudsPos = new List<GameObject>();
    [SerializeField] List<GameObject> combineIdeaClouds = new List<GameObject>();

    [SerializeField] private CombineItems combineItems;
    [SerializeField] private CombineMode combineMode;

    private const int maxAllowedNames = 3;
    private const int minAllowedNames = 0;

    private void OnEnable()
    {
        combineItems.onCombined += ActivateClouds;
        combineItems.onFinishCombine += DeActivateClouds;
        combineMode.onExitCombineMode += DeActivateClouds;
    }
    private void OnDisable()
    {
        combineItems.onCombined -= ActivateClouds;
        combineItems.onFinishCombine += DeActivateClouds;
        combineMode.onExitCombineMode -= DeActivateClouds;
    }

    public void ActivateClouds(string[] names)
    {
        if (MinimumAmount(names.Length)) return;
        DeActivateClouds();

        if (TotalExceeded(names.Length)) return;
        if (ContainsSingleName(names)) return;

        for (int i = 0; i < names.Length; i++)
        {
            SetCombineCloud(combineCloudsPos[i], combineIdeaClouds[i], names[i]);
        }
    }

    private bool ContainsSingleName(string[] names)
    {
        if (names.Length == 1)
        {
            SetCombineCloud(combineCloudsPos[2], combineIdeaClouds[2], names[0]);
            return true;
        }
        return false;
    }

    private bool MinimumAmount(int amount)
    {
        if (amount <=  minAllowedNames)
        {
            Debug.Log("Item has 0 or less stuff", this);
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

    private void SetCombineCloud(GameObject pos, GameObject cloud, string itemText)
    {
        cloud.GetComponentInChildren<TMP_Text>().text = itemText;
        cloud.transform.position = pos.transform.position;
        cloud.transform.rotation = pos.transform.rotation;
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
