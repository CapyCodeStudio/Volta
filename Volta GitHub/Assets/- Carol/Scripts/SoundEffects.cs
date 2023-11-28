using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] Slider soundEffectsSlider;



    void Start()
    {
        if (!PlayerPrefs.HasKey("soundEffectsVolume"))
        {
            PlayerPrefs.SetFloat("soundEffectsVolume", 1);
        }
        else
        {
            Load();
        }

    }


    public void ChangeVolume()
    {
        AudioListener.volume = soundEffectsSlider.value;
        Save();
    }

    private void Load()
    {
        soundEffectsSlider.value = PlayerPrefs.GetFloat("soundEffectsVolume");
    }


    private void Save()
    {
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsSlider.value);
    }
}
