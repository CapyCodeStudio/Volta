using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;

public class Trocar : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;

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
                /*comCabeca.SetActive(false);
                semCabeca.SetActive(true);*/


            }
            else
            {
               
                freeLookCamera.Priority = 5;
                virtualCamera.Priority = 0;
                /*comCabeca.SetActive(true);
                semCabeca.SetActive(false);*/
            }

            
            isFreeLookActive = !isFreeLookActive;
        }
    }
}
