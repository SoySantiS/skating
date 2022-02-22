using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Audio;

public class SongManager : MonoBehaviour
{
    public static SongManager instance;

    public static SongManager Instance => instance;

    [SerializeField] private AudioSource _song;

    private void Awake()
    {
        _song = GetComponent<AudioSource>();

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
