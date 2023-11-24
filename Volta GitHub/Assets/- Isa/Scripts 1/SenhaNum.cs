using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenhaNum : MonoBehaviour
{
    //[SerializeField] public GameObject ouvirMensagem;
    public bool tocando;
    public Camera main1;
    public Camera main2;
    public GameObject voltar;
    public GameObject imagem;
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
            if (Input.GetButton("E"))
            {
                print("teste");
                Cursor.lockState = CursorLockMode.None;
                main1.gameObject.SetActive(false);
                main2.gameObject.SetActive(true);
                voltar.SetActive(true);
                imagem.SetActive(true);

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
            imagem.SetActive(false);

        }
    }

}
