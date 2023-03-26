using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject currentMenu;

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

            currentMenu.SetActive(false);
        }
        else if (inputReader.inputActions.PlayerInput.enabled)
        {
            currentMenu.SetActive(true);
        }
    }
}
