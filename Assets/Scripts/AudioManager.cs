using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource mySource;

    private void Awake()
    {
        //Play(2);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Play (int index)
    {
        mySource.clip = sounds[index];
        mySource.Play();
        //sounds[index].
        
    }
}
