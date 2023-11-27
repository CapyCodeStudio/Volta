using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendasUniverso1 : MonoBehaviour
{
    public GameObject FALA1;
    public GameObject FALA2;
    private float tempoDeEsperaAtivarF1 = 1.5f;
    private float tempoDeEsperaDesativarF1 = 3.0f;
    private float tempoDeEsperaAtivarF2 = 5.5f;
    private float tempoDeEsperaDesativarF2 = 2.0f;

    private void Start()
    {
        Invoke("AtivarLegenda", tempoDeEsperaAtivarF1);
        Invoke("AtivarLegenda2", tempoDeEsperaAtivarF2);
    }

    private void AtivarLegenda()
    {
        if (FALA1 != null)
        {
            FALA1.SetActive(true);
            
            Invoke("DesativarLegenda", tempoDeEsperaDesativarF1);
        }
    }

    private void DesativarLegenda()
    {
        if (FALA1 != null)
        {
            FALA1.SetActive(false);
        }
    }

    private void AtivarLegenda2()
    {
        if (FALA2 != null)
        {
            FALA2.SetActive(true);
            
            Invoke("DesativarLegenda2", tempoDeEsperaDesativarF2);
        }
    }

    private void DesativarLegenda2()
    {
        if (FALA2 != null)
        {
            FALA2.SetActive(false);
        }
    }

}
