using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BackUp : MonoBehaviour
{
    // UI Document component
    UIDocument menuUIDocument;

    // Visual Elements
    Button btnStart;
    Button btnSettings;
    Button btnExit;

    [SerializeField] string mainMenuScene;
    [SerializeField] string firstLevelScene;

    void OnEnable()
    {
        menuUIDocument = GetComponent<UIDocument>();

        // Debug Null Reference
        if (menuUIDocument == null)
        {
            Debug.Log("No UIDocument Found On This Game Object");
        }

        // Main Menu Visual Elements
        btnStart = menuUIDocument.rootVisualElement.Q("btnStart") as Button;
        btnSettings = menuUIDocument.rootVisualElement.Q("btnSettings") as Button;
        btnExit = menuUIDocument.rootVisualElement.Q("btnExit") as Button;

        // On enable load the 
        MainMenuEvents();
    }
    private void MainMenuEvents()
    {
        btnStart.clicked += () => SceneManager.LoadScene(firstLevelScene);
        //btnSettings.clicked += ShowSettingsMenu();
        btnExit.clicked += () => Application.Quit();
    }
}

