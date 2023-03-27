using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject mainMenu, settingsMenu;
    // UI Document component
    UIDocument menuUIDocument;

    // Visual Elements
    Button btnStart;
    Button btnSettings;
    Button btnExit;

    [SerializeField] int startingLevelIndex;

    void OnEnable()
    {
        inputReader.EnableUI();
        Time.timeScale = 0f;

        
        MainMenuEvents();
        Debugging();
    }

    private void MainMenuEvents()
    {
        // ------------- LOGIC -----------------
        menuUIDocument = GetComponent<UIDocument>();
        VisualElement root = menuUIDocument.rootVisualElement;
        btnStart = (Button)root.Q("btnStart");
        btnSettings = (Button)root.Q("btnSettings");
        btnExit = (Button)root.Q("btnExit");

        // ------------- EVENTS -----------------
        btnStart.clicked += () => {
            inputReader.EnableGameplay();
            SceneManager.LoadScene(startingLevelIndex);
            Debug.Log("start clicked");
        };
        btnSettings.clicked += () => { settingsMenu.SetActive(true); mainMenu.SetActive(false); };
        btnExit.clicked += () =>
        {
            Application.Quit();
            Debug.Log("exit clicked");
        };
    }








    // ------------- REMOVE THIS -----------------

    void Debugging()
    {
        if (menuUIDocument == null)
        {
            Debug.Log("No UIDocument Found On This Game Object.");
        }
        if (mainMenu == null)
        {
            Debug.Log("Define Main Menu in inspector.");

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