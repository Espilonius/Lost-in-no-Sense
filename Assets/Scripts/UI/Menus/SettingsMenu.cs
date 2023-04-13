using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    [SerializeField] PlayerSettings ps;
    [SerializeField] InputReader inputReader;
    [SerializeField] Slider volume, horizontal, vertical;
    [SerializeField] Toggle invertY;
    [SerializeField] float defaultVolume = 5f;
    [SerializeField] float minVolume = -80f;
    [SerializeField] float maxVolume = 15f;

    private void OnEnable()
    {
        inputReader.EnableUI();
        invertY.isOn = ps.InvertY;
        horizontal.value = ps.HorizontalSensitivity;
        vertical.value = ps.VerticalSensitivity;



        // Set slider values
        volume.minValue = minVolume;
        volume.maxValue = maxVolume;
        volume.value = defaultVolume;
        audioMixer.SetFloat("Volume", defaultVolume);

    }
    private void ConvertToResolution(string text)
    {
        string[] resolutions = text.Split("x");
        Screen.SetResolution(int.Parse(resolutions[0].Trim()), int.Parse(resolutions[1].Trim()), Screen.fullScreen);
    }
    public void ToggleResolution(int index) => ConvertToResolution(resolutionDropdown.options[index].text);
    public void FullscreenToggle(bool isFullscreen) => Screen.fullScreen = isFullscreen;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
    public void SetHorizontal(float horizontal) => ps.SetHorizontal(horizontal);
    public void SetVertical(float vertical) => ps.SetVertical(vertical);
    public void InvertY(bool value) => ps.SetInvertY(value);

}
