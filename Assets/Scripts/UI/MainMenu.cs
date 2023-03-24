using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    // UI Document component
    UIDocument menuUIDocument;

    // Visual Elements
    Button btnStart;
    Button btnSettings;
    Button btnExit;
    Button btnResume;
    Button btnMain;
    Button btnBack;
    Slider sliderH;
    Slider sliderV;
    Slider sliderVolume;
    Toggle toggleFullscreen;
    Toggle toggleInvertY;
    DropdownField ddfResolutions;
    VisualElement UIbackground;
    Label lbTitle;
    Label lbSettings;

    // Settings
    //[SerializeField] private InputReader inputReader;
    [SerializeField] private string mainMenuScene;
    [SerializeField] string firstLevelScene;

    
    void OnEnable()
    {
        menuUIDocument = GetComponent<UIDocument>();

        // Debug Null Reference
        if(menuUIDocument == null)
        {
            Debug.Log("No Visual Elements found");
        }


        // Background
            UIbackground = menuUIDocument.rootVisualElement.Q("background");
        // Text
        lbTitle = menuUIDocument.rootVisualElement.Q("lbTitle") as Label;
        lbSettings = menuUIDocument.rootVisualElement.Q("lbSettings") as Label;


        // Main Menu Visual Elements
        btnStart = menuUIDocument.rootVisualElement.Q("btnStart") as Button;
            btnSettings = menuUIDocument.rootVisualElement.Q("btnSettings") as Button;
            btnExit = menuUIDocument.rootVisualElement.Q("btnExit") as Button;
        // Pause Menu Visual Elements
            btnResume = menuUIDocument.rootVisualElement.Q("btnResume") as Button;
            btnMain = menuUIDocument.rootVisualElement.Q("btnMain") as Button;
        // Settings Menu Visual Elements
            btnBack = menuUIDocument.rootVisualElement.Q("btnBack") as Button;

            sliderH = menuUIDocument.rootVisualElement.Q("sliderH") as Slider;
            sliderV = menuUIDocument.rootVisualElement.Q("sliderV") as Slider;
            sliderVolume = menuUIDocument.rootVisualElement.Q("sliderVolume") as Slider;

            toggleFullscreen = menuUIDocument.rootVisualElement.Q("toggleFullscreen") as Toggle;
            toggleInvertY = menuUIDocument.rootVisualElement.Q("toggleInvertY") as Toggle;

            ddfResolutions = menuUIDocument.rootVisualElement.Q("ddfResolutions") as DropdownField;


        // On enable load the 
        ShowMainMenu();

        // Adding Menu Events
        //PauseMenuEvents();
        //SettingsMenuEvents();
    }

    // Remove the UI 
    void HideAllElements()
    {
        UIbackground.AddToClassList("hide"); 
        lbTitle.AddToClassList("hide");
        lbSettings.AddToClassList("hide");
        btnStart.AddToClassList("hide");
        btnExit.AddToClassList("hide");
        btnSettings.AddToClassList("hide");
        btnResume.AddToClassList("hide");
        btnMain.AddToClassList("hide");
        btnBack.AddToClassList("hide");
        sliderH.AddToClassList("hide");
        sliderV.AddToClassList("hide");
        sliderVolume.AddToClassList("hide");
        toggleFullscreen.AddToClassList("hide");
        toggleInvertY.AddToClassList("hide");
        ddfResolutions.AddToClassList("hide");
    }
    // Show the Menus
    void ShowMainMenu()
    {
        // Loads the main menu scene before opening the menu.
        HideAllElements();
        UIbackground.RemoveFromClassList("hide");
        lbTitle.RemoveFromClassList("hide");
        btnStart.RemoveFromClassList("hide");
        btnSettings.RemoveFromClassList("hide");
        btnExit.RemoveFromClassList("hide");
        MainMenuEvents();

    }
    void ShowSettingsMenu()
    {
        HideAllElements();

        UIbackground.RemoveFromClassList("hide");
        lbSettings.RemoveFromClassList("hide");
        btnBack.RemoveFromClassList("hide");
        sliderH.RemoveFromClassList("hide");
        sliderV.RemoveFromClassList("hide");
        sliderVolume.RemoveFromClassList("hide");
        toggleFullscreen.RemoveFromClassList("hide");
        toggleInvertY.RemoveFromClassList("hide");
        ddfResolutions.RemoveFromClassList("hide");
    }
    void ShowPauseMenu()
    {
        HideAllElements();
        //inputReader.DisableGameplay();
        UIbackground.RemoveFromClassList("hide");
        lbTitle.RemoveFromClassList("hide");
        btnSettings.RemoveFromClassList("hide");
        btnResume.RemoveFromClassList("hide");
        btnMain.RemoveFromClassList("hide");
    }



    private void MainMenuEvents()
    {
        btnStart.clicked += () => {
            SceneManager.LoadScene(firstLevelScene,LoadSceneMode.Single);
            HideAllElements();
        };
        btnSettings.clicked += () => { 
            ShowSettingsMenu();
        };
        btnExit.clicked += () => {
            Application.Quit();
        };
    }
    private void PauseMenuEvents()
    {
        btnResume.clicked += () =>
        {
            //inputReader.EnableGameplay();
            HideAllElements();
        };
        btnSettings.clicked += () =>
        {
            ShowSettingsMenu();
        };

        btnMain.clicked += () =>
        {
            SceneManager.LoadScene(mainMenuScene);
            ShowMainMenu();
        };
    }
    private void SettingsMenuEvents()
    {
        btnBack.clicked += () => {
            SceneManager.LoadScene(firstLevelScene);
            HideAllElements();
        };
    }
}
 