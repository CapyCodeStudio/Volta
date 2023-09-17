using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    public GameObject cutscenecreditos;

    private void Start()
    {
        
        if (cutscenecreditos != null)
        {
            cutscenecreditos.SetActive(false);
        }
    }

    public void AtivarCutscene()
    {
        
        if (cutscenecreditos != null)
        {
            cutscenecreditos.SetActive(true);
        }
    }

    public void DesativarCutscene()
    {
        
        if (cutscenecreditos != null)
        {
            cutscenecreditos.SetActive(false);
        }
    }
}
