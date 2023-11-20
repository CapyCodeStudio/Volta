using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class Trocar1 : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject mesh;
    public GameObject luzTERCEIRA;
    public GameObject luzPRIMEIRA;
    public GameObject VoyagerPRIMEIRA;
    public GameObject VoyagerTERCEIRA;
   
    private bool isFreeLookActive = true;

    private void Start()
    {
        freeLookCamera.Priority = 5;
        virtualCamera.Priority = 0;
    }

    private void Update()
    {

        if (Input.GetButtonDown("C"))
        {
            if (isFreeLookActive)
            {
                mesh.SetActive(false);
                luzPRIMEIRA.SetActive(true);
                luzTERCEIRA.SetActive(false);
                VoyagerPRIMEIRA.SetActive(true);
                VoyagerTERCEIRA.SetActive(false);
                freeLookCamera.Priority = 0;
                virtualCamera.Priority = 5;

            }
            else
            {
                // Terceira Pessoa
                freeLookCamera.Priority = 5;
                virtualCamera.Priority = 0;
                luzPRIMEIRA.SetActive(false);
                luzTERCEIRA.SetActive(true);
                VoyagerPRIMEIRA.SetActive(false);
                VoyagerTERCEIRA.SetActive(true);
                mesh.SetActive(true);
            }


            isFreeLookActive = !isFreeLookActive;
        }


    }


}
