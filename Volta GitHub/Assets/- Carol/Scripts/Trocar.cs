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
    public GameObject luzTERCEIRA;
    public GameObject luzPRIMEIRA;
    public GameObject VoyagerPrimeira;
    public GameObject VoyagerTERCEIRA;
   
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
                VoyagerPrimeira.SetActive(true);
                VoyagerTERCEIRA.SetActive(false);
            }
            else
            {
               
                freeLookCamera.Priority = 5;
                virtualCamera.Priority = 0;
                mesh.SetActive(true);
                luzPRIMEIRA.SetActive(false);
                luzTERCEIRA.SetActive(true);
                VoyagerPrimeira.SetActive(false);
                VoyagerTERCEIRA.SetActive(true);

            }

            
            isFreeLookActive = !isFreeLookActive;
        }
    }
}
