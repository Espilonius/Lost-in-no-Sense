using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlay : MonoBehaviour
{
    [SerializeField] AudioSource overallVolume;
    [SerializeField] AudioClip menuMusic;
    private void Start()
    {
        overallVolume.clip = menuMusic;
        overallVolume.loop = true;
        overallVolume.Play();
    }
    private void OnDisable()
    {
        // Stop the audio clip
        overallVolume.Stop();
    }
}
