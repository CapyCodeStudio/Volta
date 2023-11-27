/*using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }

        musicSlider.value = Staticos.volume;

    }


    public void ChangeVolume()
    {
        AudioListener.volume = musicSlider.value;
        Save();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }


    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    private void Update()
    {
        Staticos.volume = musicSlider.value;
        AudioSource.volume = Staticos.volume;
    }
}
*/