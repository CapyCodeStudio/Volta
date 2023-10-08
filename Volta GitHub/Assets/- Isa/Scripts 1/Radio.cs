using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Radio : MonoBehaviour
{ 
    public AudioSource audioSource; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            print("musica");
            if (!audioSource.isPlaying)
            {
                
                audioSource.Play();
            }
        }
    }
}




