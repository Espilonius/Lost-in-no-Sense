using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject menu;

    private void OnEnable()
    {
        inputReader.escapeEvent += Escape;
    }
    private void OnDisable()
    {
        inputReader.escapeEvent -= Escape;
    }
    private void Escape()
    {
        if (inputReader.inputActions.UI.enabled)
        {

            menu.SetActive(false);
        }
        else if (inputReader.inputActions.PlayerInput.enabled)
        {
            menu.SetActive(true);
        }
    }
}
