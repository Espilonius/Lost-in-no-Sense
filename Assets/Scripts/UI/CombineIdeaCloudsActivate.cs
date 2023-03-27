using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombineIdeaCloudsActivate : MonoBehaviour
{
    [SerializeField] List<GameObject> combineIdeaClouds = new List<GameObject>();

    public void ActivateClouds(List<string> items)
    {
        DeActivateClouds();
        if (items.Count == 1)
        {
            SetCombineCloud(1, items[0]);
        }
        else if (items.Count == 2)
        {
            SetCombineCloud(0, items[0]);
            SetCombineCloud(2, items[1]);
        }
        else if (items.Count == 3)
        {
            int index = 0;
            foreach (GameObject combineCloud in combineIdeaClouds)
            {
                SetCombineCloud(index, items[index]);
                index++;
            }
        }
    }

    private void SetCombineCloud(int indexCloud, string itemText)
    {
        combineIdeaClouds[indexCloud].GetComponentInChildren<TMP_Text>().text = itemText;
        combineIdeaClouds[indexCloud].SetActive(true);
    }

    public void DeActivateClouds()
    {
        foreach (GameObject combineCloud in combineIdeaClouds)
        {
            combineCloud.SetActive(false);
        }
    }
}
