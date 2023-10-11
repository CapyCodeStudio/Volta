using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
public class CameraP : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public CinemachineVirtualCamera virtualCamera;
    /*public GameObject comCabeca;
    public GameObject semCabeca;*/
    public Collider areaTrigger;
    private void OnTriggerEnter(Collider other)
    {
        print("Deu certo");
        if (other.CompareTag("Player"))
        {
            freeLookCamera.gameObject.SetActive(false);
            virtualCamera.gameObject.SetActive(true);
            /*comCabeca.SetActive(false);
            semCabeca.SetActive(true);*/
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            freeLookCamera.gameObject.SetActive(true);
            virtualCamera.gameObject.SetActive(false);
            /*comCabeca.SetActive(true);
            semCabeca.SetActive(false);*/
        }
    }
}
