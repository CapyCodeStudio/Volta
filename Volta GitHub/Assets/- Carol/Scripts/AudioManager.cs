using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private static readonly string AmbiencePref = "AmbiencePref";

    public AudioSource musicAudio;
    public AudioSource[] soundEffectsAudio;
    public AudioSource[] ambienceAudio;

    private int firstPlayInt;
    public Slider musicSlider, sondEffectsSlider, ambienceSlider;
    private float musicFloat, sondEffectsFloat, ambienceFloat;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            musicFloat = 1f;
            sondEffectsFloat = 1f;
            ambienceFloat = 1f;
            musicSlider.value = musicFloat;
            sondEffectsSlider.value = sondEffectsFloat;
            ambienceSlider.value = ambienceFloat;

            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, sondEffectsFloat);
            PlayerPrefs.SetFloat(AmbiencePref, ambienceFloat);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            sondEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            sondEffectsSlider.value = sondEffectsFloat;
            ambienceFloat = PlayerPrefs.GetFloat(AmbiencePref);
            ambienceSlider.value = ambienceFloat;
        }

    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, sondEffectsSlider.value);
        PlayerPrefs.SetFloat(AmbiencePref, ambienceSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;

        for(int i = 0; 1< soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = sondEffectsSlider.value;
        }

        for (int i = 0; 1 < ambienceAudio.Length; i++)
        {
            ambienceAudio[i].volume = ambienceSlider.value;
        }


    }


}
