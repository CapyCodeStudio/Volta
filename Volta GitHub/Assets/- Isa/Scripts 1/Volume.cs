using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Volume : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxVolume = 1;
    public float volumeIncrease = 0.1f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (audioSource.volume < maxVolume)
            {
                audioSource.volume += volumeIncrease;
                if (audioSource.volume > maxVolume)
                {
                    audioSource.volume = maxVolume;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.volume = 1.0f;
        }
    }
}


