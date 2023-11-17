using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenhaMorse : MonoBehaviour
{
    //[SerializeField] public GameObject ouvirMensagem;
    public bool tocando;
    public void Update()
    {
        if (tocando)
        {

            // ouvirMensagem.SetActive(true);
        }
        else
        {
           //ouvirMensagem.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
            if (Input.GetButtonDown("C"))
            {
                SceneManager.LoadScene("SenhaMorse");
            }
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = false;

        }
    }
}
