using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class btnFX : MonoBehaviour
{
    [SerializeField] AudioSource btnFx;
    [SerializeField] AudioClip hoverFx;
    [SerializeField] AudioClip clickFx;

    private TMP_Text textComponent;
    private FontStyles originalFontStyle;


    private void Awake()
    {
        textComponent = GetComponentInChildren<TMP_Text>();
        originalFontStyle = textComponent.fontStyle;
    }

    public void PointerEnter()
    {
        btnFx.PlayOneShot(hoverFx);
        textComponent.fontStyle = originalFontStyle | FontStyles.Bold | FontStyles.UpperCase;
    }
    public void PointerDown()
    {
        btnFx.PlayOneShot(clickFx);
        textComponent.fontStyle = originalFontStyle | FontStyles.UpperCase; 


    }
    public void PointerExit()
    {
        textComponent.fontStyle = originalFontStyle;

    }

}
