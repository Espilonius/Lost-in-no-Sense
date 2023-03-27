using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] PlayerSettings ps;
    [SerializeField] InputReader inputReader;
    [SerializeField] GameObject settingsMenu, currentMenu;

    // UI Document component
    UIDocument menuUIDocument;

    // Visual Elements
    Toggle toggleInvertY;
    Slider sliderV;
    Slider sliderH;

    // ------------- UPDATE THIS --------------
    AudioMixer audioMixer;
    Button btnBack;
    Toggle toggleFullscreen;
    DropdownField ddfResolutions;
    Slider sliderVolume;
    // -------------------------------------------


    private void OnEnable()
    {

        inputReader.EnableUI();
        SettingsMenuEvents();

        // ------------- REMOVE THIS -----------------

        Debugging();

        // -------------------------------------------
    }

    void SettingsMenuEvents()
    {
        // ------------- LOGIC -----------------
        menuUIDocument = GetComponent<UIDocument>();
        VisualElement root = menuUIDocument.rootVisualElement;
        btnBack = (Button)root.Q("btnBack");
        sliderH = (Slider)root.Q("sliderH");
        sliderV = (Slider)root.Q("sliderV");
        sliderVolume = (Slider)root.Q("sliderVolume");
        toggleFullscreen = (Toggle)root.Q("toggleFullscreen");
        toggleInvertY = (Toggle)root.Q("toggleInvertY");
        ddfResolutions = (DropdownField)root.Q("ddfResolutions");

        // ------------- EVENTS -----------------
        btnBack.clicked += () => { settingsMenu.SetActive(false); currentMenu.SetActive(true); };
        toggleInvertY.value = ps.InvertY;
        sliderH.value = ps.HorizontalSensitivity;
        sliderV.value = ps.VerticalSensitivity;
        Debug.Log(toggleInvertY.value);
        //toggleFullscreen.value = ps.toggleFullscreen;
        //audioMixer.GetFloat("Volume", out float vol);
        //sliderVolume.value = vol;
    }

    // ------------- UPDATE THIS --------------

    // ------------- OLD CODE -----------------
    /*    private void ConvertToResolution(string text)
        {
            string[] resolutions = text.Split("x");
            Screen.SetResolution(int.Parse(resolutions[0].Trim()), int.Parse(resolutions[1].Trim()), Screen.fullScreen);
        }*/
    //public void ToggleResolution(int index) => ConvertToResolution(ddfResolutions.options[index].text);
    public void FullscreenToggle(bool isFullscreen) => Screen.fullScreen = isFullscreen;
    //public void SetVolume(float volume) => audioMixer.SetFloat("Volume", volume);

    // ------------- NEW CODE -----------------
    // Cant use until playersettings is updated by adding the setfullscreen method.
    //public void FullscreenToggle(bool isFullscreen) => ps.SetFullscreen(isFullscreen);

    public void SetHorizontal(float horizontal) => ps.SetHorizontal(horizontal);
    public void SetVertical(float vertical) => ps.SetVertical(vertical);
    public void InvertY(bool value) => ps.SetInvertY(value);










    // ------------- REMOVE THIS -----------------

    void Debugging()
    {
        if (menuUIDocument == null)
        {
            Debug.Log("No UIDocument Found On This Game Object.");
        }
        if (currentMenu == null)
        {
            Debug.Log("Define Current Menu in inspector.");

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
