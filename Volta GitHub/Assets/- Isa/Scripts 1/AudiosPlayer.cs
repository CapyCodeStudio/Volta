using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioClip[] passosAudioClip;

    [SerializeField] private AudioSource correrAudioSource;
    [SerializeField] private AudioClip[] correrAudioClip;

    [SerializeField] private AudioSource puloAudioSource;
    [SerializeField] private AudioClip[] puloAudioClip;
    public void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }
 
    public void Correr()
    {
        correrAudioSource.PlayOneShot(correrAudioClip[Random.Range(0, correrAudioClip.Length)]);
    }
   
    public void Pulo()
    {
        puloAudioSource.PlayOneShot(correrAudioClip[Random.Range(0, puloAudioClip.Length)]);
    }

}
