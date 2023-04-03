using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    AudioSource audioSource;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    } 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySe(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
