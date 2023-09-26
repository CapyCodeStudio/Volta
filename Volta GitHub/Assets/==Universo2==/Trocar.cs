using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trocar : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;

    private bool isFreeLookActive = true;

    private void Start()
    {
        // Ative a câmera Free Look inicialmente
        freeLookCamera.Priority = 10;
        virtualCamera.Priority = 0;
    }

    private void Update()
    {
        // Detecte a tecla ou botão que você deseja usar para alternar as câmeras (por exemplo, a tecla C)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isFreeLookActive)
            {
                // Desative a câmera Free Look e ative a câmera Virtual
                freeLookCamera.Priority = 0;
                virtualCamera.Priority = 10;
            }
            else
            {
                // Desative a câmera Virtual e ative a câmera Free Look
                freeLookCamera.Priority = 10;
                virtualCamera.Priority = 0;
            }

            // Inverta o estado
            isFreeLookActive = !isFreeLookActive;
        }
    }
}
