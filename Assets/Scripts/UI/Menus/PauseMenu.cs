using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject pauseMenu, settingsMenu;
    private void OnEnable()
    {
        inputReader.EnableUI();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
        inputReader.EnableGameplay();
    }




}
