using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraP : MonoBehaviour
{
    public bool tocando;
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject trigger;
    public GameObject mesh;
    public GameObject UICAVE;
    public GameObject UITUTORIAL1;
    public GameObject VoyagerTerceiraPessoa;
    public GameObject VoyagerPrimeiraPessoa;
    public GameObject GravadorPrimeira;
    public GameObject GravadorTerceira; 

    private float tempoDeEspera = 2.0f;

    private void Start()
    {
        Invoke("AtivarUITutorial", tempoDeEspera);
    }

    private void AtivarUITutorial()
    {
        if (UITUTORIAL1 != null)
        {
            UITUTORIAL1.SetActive(true);
        }
    }

    private void Update()
    {

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mesh.SetActive(false);
            tocando = true;
            freeLookCamera.Priority = 0;
            virtualCamera.Priority = 5;
            UICAVE.SetActive(false);
            VoyagerTerceiraPessoa.SetActive(false);
            


        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mesh.SetActive(true);
            tocando = false;
            freeLookCamera.Priority = 5;
            virtualCamera.Priority = 0;
            UICAVE.SetActive(true);
            VoyagerTerceiraPessoa.SetActive(true);
            VoyagerPrimeiraPessoa.SetActive(false);


        }
    }

}

