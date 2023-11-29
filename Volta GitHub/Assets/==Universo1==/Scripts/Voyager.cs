using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voyager : MonoBehaviour
{
    public bool tocando;
    public GameObject e;
    public GameObject cara;
    public GameObject chao;
   
    private void Update()
    {
        print("AAAAAAA");
        if (tocando && cara.activeSelf == false)
        {
            e.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("E"))
            {
                if (cara.activeSelf)
                {
                    cara.SetActive(false);
                    chao.SetActive(false);
                    e.SetActive(false);
                   

                }
                else
                {
                    print("aperto o botao");
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

