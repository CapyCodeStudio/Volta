using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicaSlider;
    [SerializeField] private Slider efeitosSlider;

    public void Start()
    {
        if(PlayerPrefs.HasKey("volumeMusica"))
        {
            LoadVolume();
        }
        else
        {
            SetVolumeMusica();
            SetVolumeEfeitos();
        }

    }
    public void SetVolumeMusica()
    {
        float volume = musicaSlider.value;
        mixer.SetFloat("musica", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeMusica", volume);
    }

    public void SetVolumeEfeitos()
    {
        float volume = efeitosSlider.value;
        mixer.SetFloat("efeitos", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeEfeitos", volume);
    }

    public void LoadVolume()
    {
        musicaSlider.value = PlayerPrefs.GetFloat("volumeMusica");
        efeitosSlider.value = PlayerPrefs.GetFloat("volumeEfeitos");

        SetVolumeMusica();
        SetVolumeEfeitos();
    }



}
