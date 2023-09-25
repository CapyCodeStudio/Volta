using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public bool tocando;
    // public BoxCollider carta;
    public GameObject e;
    public GameObject carta;


    private void Update()
    {
        if (tocando)
        {
            e.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("E"))
            {
                print("aperto o botao");
                carta.SetActive(true);
                e.SetActive(false);
                Time.timeScale = 0;
                //carta.isTrigger = true;
                /*if (Input.GetButtonDown("E") && carta == true)
                {
                    carta.SetActive(false);
                    e.SetActive(false);
                    Time .timeScale = 1;
                }*/

            }
        }


        


    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("passou");
            tocando = true;
        }

    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("saiu");
            tocando = false;
        }
    }
}

