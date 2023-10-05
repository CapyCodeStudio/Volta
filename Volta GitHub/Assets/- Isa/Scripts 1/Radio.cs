using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
public enum Audio
{
    Um, Dois, Tres, Quatro
}
public class Radio : MonoBehaviour
{
    AudioSource audioS;
    public static Radio instance;
    
    public static void PlaySound(Audio sound)
    {
       switch (sound)
        {
            //case Radio.Um:

        }
    }

}


