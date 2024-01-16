using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    public SceneManager.SoundState soundState;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
