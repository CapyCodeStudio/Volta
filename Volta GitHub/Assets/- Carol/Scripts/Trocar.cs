using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trocar : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject mesh;

    private bool isFreeLookActive = true;

    private void Start()
    {
        // Ative a c�mera Free Look inicialmente
        freeLookCamera.Priority = 5;
        virtualCamera.Priority = 0;
    }

    private void Update()
    {
        // Detecte a tecla ou bot�o que voc� deseja usar para alternar as c�meras (por exemplo, a tecla C)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isFreeLookActive)
            {
                // Desative a c�mera Free Look e ative a c�mera Virtual
                freeLookCamera.Priority = 0;
                virtualCamera.Priority = 5;
                mesh.SetActive(false);

            }
            else
            {
                // Desative a c�mera Virtual e ative a c�mera Free Look
                freeLookCamera.Priority = 5;
                virtualCamera.Priority = 0;
                mesh.SetActive(true);
            }

            // Inverta o estado
            isFreeLookActive = !isFreeLookActive;
        }
    }
}
