using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string firstLevelScene = "Level01";
    [SerializeField] private InputReader inputReader;

    private void OnEnable()
    {
        inputReader.EnableUI();
    }
    public void PlayButtonClicked()
    {
        inputReader.EnableGameplay();
        SceneManager.LoadScene(firstLevelScene);
    }
    public void QuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("You are leaving the game.");
    }

}
