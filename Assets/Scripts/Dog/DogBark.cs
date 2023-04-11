using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBark : MonoBehaviour
{
    [SerializeField] AudioClip[] dogClipsArray;
    [SerializeField] AudioSource dogSource;

    private int selectDog;
    private float dogPitch;
    private float timer;
    private float time;

    // Start is called before the first frame update
    void Start()
    {   
        dogPitch = Random.Range(0.5f, 1.5f);
        selectDog = Random.Range(0, dogClipsArray.Length);
        time = Random.Range(2.5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            // Play Sound
            dogSource.clip = dogClipsArray[selectDog];
            dogSource.pitch = dogPitch;
            dogSource.Play();


            // Recalculate
            timer = 0;
            dogPitch = Random.Range(0.5f, 1.5f);
            selectDog = Random.Range(0, dogClipsArray.Length);
            time = Random.Range(2.5f, 5f);
        }

    }
}
