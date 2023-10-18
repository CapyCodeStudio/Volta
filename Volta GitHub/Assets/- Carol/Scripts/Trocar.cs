using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;

public class Trocar : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject mesh;
    public GameObject luzPRIMEIRA;
    public GameObject luzTERCEIRA;

    private bool isFreeLookActive = true;

    private void Start()
    {
        freeLookCamera.Priority = 5;
        virtualCamera.Priority = 0;
    }

    private void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isFreeLookActive)
            { 
                freeLookCamera.Priority = 0;
                virtualCamera.Priority = 5;
                mesh.SetActive(false);
                luzPRIMEIRA.SetActive(true); 
                luzTERCEIRA.SetActive(false);

            }
            else
            {
               
                freeLookCamera.Priority = 5;
                virtualCamera.Priority = 0;
                mesh.SetActive(true);
                luzPRIMEIRA.SetActive(false);
                luzTERCEIRA.SetActive(true);
            }

            
            isFreeLookActive = !isFreeLookActive;
        }
    }
}
