using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioClip[] passosAudioClip;
    [SerializeField] private AudioSource correrAudioSource;
    [SerializeField] private AudioClip[] correrAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }
    public void Correr()
    {
        correrAudioSource.PlayOneShot(correrAudioClip[Random.Range(0, correrAudioClip.Length)]);
    }
}
