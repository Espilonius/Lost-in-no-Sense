using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject pauseMenu, settingsMenu;

    // UI Document component
    UIDocument menuUIDocument;

    // Visual Elements
    Button btnResume;
    Button btnSettings;
    Button btnMain;

    private void OnEnable()
    {
        Debug.Log(inputReader);

        inputReader.EnableUI();
        Time.timeScale = 0f;
        Debug.Log(inputReader);

        // Everytime the pause menu is reopened, make sure the settings menu is closed.
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);


        PauseMenuEvents();
        Debugging();
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        inputReader.EnableGameplay();
    }


    void PauseMenuEvents()
    {
        // ------------- LOGIC -----------------
        menuUIDocument = GetComponent<UIDocument>();
        VisualElement root = menuUIDocument.rootVisualElement;
        btnSettings = (Button)root.Q("btnSettings");
        btnResume = (Button)root.Q("btnResume");
        btnMain = (Button)root.Q("btnMain");

        // ------------- EVENTS -----------------
        btnResume.clicked += () => pauseMenu.SetActive(false);
        btnSettings.clicked += () => { settingsMenu.SetActive(true); pauseMenu.SetActive(false); } ;
        btnMain.clicked += () => SceneManager.LoadScene("MainMenuScene");
    }









    // ------------- REMOVE THIS -----------------

    void Debugging()
    {
        if (menuUIDocument == null)
        {
            Debug.Log("No UIDocument Found On This Game Object.");
        }
        if (pauseMenu == null)
        {
            Debug.Log("Define Pause Menu in inspector.");

        }
        if (settingsMenu == null)
        {
            Debug.Log("Define Settings Menu in inspector");
        }
        if (inputReader == null)
        {
            Debug.Log("Define Input Reader in inspector");
        }
    }

    // -------------------------------------------

}

