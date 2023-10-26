using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class Trocar : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject mesh;
    public GameObject luzTERCEIRA;
    public GameObject luzPRIMEIRA;
    public GameObject VoyagerPrimeira;
    public GameObject VoyagerTERCEIRA;
    public GameObject EspadaPRIMEIRA;
    public GameObject EspadaTERCEIRA;
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
                //Teste();
                mesh.SetActive(false);
                luzPRIMEIRA.SetActive(true);
                luzTERCEIRA.SetActive(false);
                VoyagerPrimeira.SetActive(true);
                VoyagerTERCEIRA.SetActive(false);
                freeLookCamera.Priority = 0;
                virtualCamera.Priority = 5;
                
            }
            else
            {
                //* Terceira Pessoa
                freeLookCamera.Priority = 5;
                virtualCamera.Priority = 0;
                luzPRIMEIRA.SetActive(false);
                luzTERCEIRA.SetActive(true);
                VoyagerPrimeira.SetActive(false);
                VoyagerTERCEIRA.SetActive(true);
                mesh.SetActive(true);
            }

            
            isFreeLookActive = !isFreeLookActive;
        }
    }
    IEnumerator Teste()
    {
        mesh.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        freeLookCamera.Priority = 0;
        virtualCamera.Priority = 5;
        luzPRIMEIRA.SetActive(true);
        luzTERCEIRA.SetActive(false);
        VoyagerPrimeira.SetActive(true);
        VoyagerTERCEIRA.SetActive(false);

    }

}
