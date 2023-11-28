using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenhaNum : MonoBehaviour
{
    public bool tocando;
    public Camera main1;
    public Camera main2;
    public GameObject voltar;
    public GameObject mensagem;

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
            if (Input.GetButton("E"))
            {
                
                Cursor.lockState = CursorLockMode.None;
                main1.gameObject.SetActive(false);
                main2.gameObject.SetActive(true);
                voltar.SetActive(true);
                mensagem.SetActive(false);
                

            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = false;
            Cursor.lockState = CursorLockMode.Locked;
            main1.gameObject.SetActive(true);
            main2.gameObject.SetActive(false);
            voltar.SetActive(false);
            mensagem.SetActive(true);


        }
    }

}
