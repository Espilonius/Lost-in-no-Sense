using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlay : MonoBehaviour
{
    [SerializeField] AudioSource overallVolume;
    [SerializeField] AudioClip ambienceSPX;
    private void OnEnable()
    {
        overallVolume.clip = ambienceSPX;
        overallVolume.loop = true;
        overallVolume.Play();
    }
    private void OnDisable()
    {
        // Stop the audio clip
        overallVolume.Stop();
    }
}
