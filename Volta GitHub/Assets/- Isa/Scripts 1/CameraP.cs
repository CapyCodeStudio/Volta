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
    public GameObject VoyagerTERCEIRA;
    public GameObject VoyagerPRIMEIRA;
    public GameObject GravadorPRIMEIRA;
    public GameObject GravadorTERCIERA;
    public GameObject VoyagerChao;
    public GameObject GravadorChao;

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
            VoyagerTERCEIRA.SetActive(false);
            VoyagerPRIMEIRA.SetActive(true);

            if (VoyagerChao)
            {
                VoyagerChao.SetActive(true);
                VoyagerTERCEIRA.SetActive(false);
                VoyagerPRIMEIRA.SetActive(false);
            }
            else
            {
                VoyagerChao.SetActive(false);
                VoyagerTERCEIRA.SetActive(true);
                VoyagerPRIMEIRA.SetActive(true);
            }


        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mesh.SetActive(true);
            tocando = false;
            print(tocando);
            freeLookCamera.Priority = 5;
            virtualCamera.Priority = 0;
            UICAVE.SetActive(true);
            VoyagerTERCEIRA.SetActive(true);
            VoyagerPRIMEIRA.SetActive(false);
            GravadorPRIMEIRA.SetActive(false);
        }
    }
}

