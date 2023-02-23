using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerPitchRandomizer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float pitchRange = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.pitch = 1 + UnityEngine.Random.Range(-pitchRange, pitchRange);
        audioSource.Play();
    }


}
