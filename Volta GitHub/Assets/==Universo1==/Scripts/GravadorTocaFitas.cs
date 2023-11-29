using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravadorTocaFitas : MonoBehaviour
{
    public bool tocando;
    public GameObject e;
    public GameObject cara;
    public GameObject chao;
    public GameObject porta;
    public GameObject portaAnimation;
 
    private void Update()
    {
        if (tocando && cara.activeSelf == false)
        {
            e.SetActive(true);
            if (Input.GetButtonDown("E"))
            {
                if (cara.activeSelf)
                {
                    cara.SetActive(false);
                    chao.SetActive(true);
                    e.SetActive(false);


                }
                else
                {
                    cara.SetActive(true);
                    chao.SetActive(false);
                    e.SetActive(false);

                }
            }
        }

        else if (tocando && cara.activeSelf == true)
        {
            if (Input.GetButtonDown("E"))
            {
                if (cara.activeSelf)
                {
                    cara.SetActive(false);
                    chao.SetActive(true);
                    e.SetActive(false);
                    

                }
            }
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
            Cursor.lockState = CursorLockMode.Locked;
            
 

        }

    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = false;
            e.SetActive(false);

        }
    }



}

