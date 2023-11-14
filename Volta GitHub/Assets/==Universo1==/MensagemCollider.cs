using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagemCollider : MonoBehaviour
{
    [SerializeField] public GameObject mensagem;
    public bool tocando;
    public void Update()
    {
        if (tocando)
        {

            mensagem.SetActive(true);
        }
        else
        {
            mensagem.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
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
