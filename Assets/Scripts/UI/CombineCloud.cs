using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombineCloud : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public string GetName()
    {
        return text.text;
    }
}
