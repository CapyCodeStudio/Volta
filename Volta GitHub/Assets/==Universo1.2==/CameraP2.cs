using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraP2 : MonoBehaviour
{
    public bool tocando;
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject trigger;
    public GameObject mesh;
    public GameObject VoyagerTERCEIRA;
    public GameObject VoyagerPRIMEIRA;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mesh.SetActive(false);
            tocando = true;
            freeLookCamera.Priority = 0;
            virtualCamera.Priority = 5;
            VoyagerTERCEIRA.SetActive(false);
            VoyagerPRIMEIRA.SetActive(true);
 
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
            VoyagerTERCEIRA.SetActive(true);
            VoyagerPRIMEIRA.SetActive(false);
          
        }
    }
}

