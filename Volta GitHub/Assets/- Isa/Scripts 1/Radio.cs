using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
public class Radio : MonoBehaviour
{
    public AudioClip audioClip; 
    private AudioSource audioSource;
    public GameObject ligado;
    public GameObject desligado;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            ligado.SetActive(false);
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
                ligado.SetActive(true);
                desligado.SetActive(false);
                
            }
            else
            {
                Debug.LogWarning("Nenhum �udio");
                ligado.SetActive(false);
            }
        }
    }
}







