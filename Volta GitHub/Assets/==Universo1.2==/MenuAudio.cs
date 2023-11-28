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
    [SerializeField] private Slider ambienteSlider;

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
            SetVolumeAmbiente();

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

    public void SetVolumeAmbiente()
    {
        float volume = ambienteSlider.value;
        mixer.SetFloat("ambiente", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeAmbiente", volume);
    }

    public void LoadVolume()
    {
        musicaSlider.value = PlayerPrefs.GetFloat("volumeMusica");       
        efeitosSlider.value = PlayerPrefs.GetFloat("volumeEfeitos");
        ambienteSlider.value = PlayerPrefs.GetFloat("volumeAmbiente");

        SetVolumeMusica();
        SetVolumeEfeitos();
        SetVolumeAmbiente();
    }



}
