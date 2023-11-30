using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRAVADOReVOYAGER1 : MonoBehaviour
{
    [SerializeField] public GameObject mensagem;
    [SerializeField] public GameObject gravadorMao;
    [SerializeField] public GameObject gravadorMesa;
    public bool tocando;
    public void Update()
    {
        if (tocando)
            mensagem.SetActive(true);
            if (Input.GetButtonDown("E"))
            {
                gravadorMesa.SetActive(false);
                gravadorMao.SetActive(true);
                mensagem.SetActive(false);

            }
            else
            {
                gravadorMesa.SetActive(true);
                gravadorMao.SetActive(false);
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

