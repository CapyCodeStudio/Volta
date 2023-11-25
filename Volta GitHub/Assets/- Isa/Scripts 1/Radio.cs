using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
public class Radio : MonoBehaviour
{
    public AudioClip audioClip; 
    private AudioSource audioSource;
    public GameObject luz;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            luz.SetActive(false);
        }

        audioSource.clip = audioClip;
    }

    void Update()
    {
        
        if (Input.GetButtonDown("E"))
        {
            
            if (audioClip != null)
            {
                
                audioSource.PlayOneShot(audioClip);
                luz.SetActive(true);
                
            }
            else
            {
                Debug.LogWarning("Nenhum áudio");
                luz.SetActive(false);
            }
        }
    }
}







