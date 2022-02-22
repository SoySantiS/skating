using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot normalSnp;

    private void Start()
    {
        normalSnp.TransitionTo(0.3f);
    }
}
