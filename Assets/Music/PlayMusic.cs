using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStart()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    public void OnStop()
    {
        audioSource.Stop(); 
    }

}
