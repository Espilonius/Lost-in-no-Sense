using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour


{    
    [SerializeField] private VisualTreeAsset mainMenuUxml;
    [SerializeField] private StyleSheet mainMenuUss;
    void OnEnable()
    {
        mainMenuUxml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/MainMenu/MainMenu.uxml");

        mainMenuUss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/StyleSheets/styles.uss");
    }
}
