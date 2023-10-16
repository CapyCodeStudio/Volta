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
    public GameObject viajante;

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
            viajante.SetActive(false);
            

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
            viajante.SetActive(true);

        }
    }

}

