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
        if (tocando && carta.activeSelf == false)
        {
            e.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("E"))
            {
                if (carta.activeSelf)
                {
                    carta.SetActive(false);
                    e.SetActive(false);
                    Time.timeScale = 1;

                }
                else
                {
                    print("aperto o botao");
                    carta.SetActive(true);
                    e.SetActive(false);
                    Time.timeScale = 0;
                }
            }
        }
        
        else if (tocando && carta.activeSelf == true)
        {
            if (Input.GetButtonDown("E"))
            {
                if (carta.activeSelf)
                {
                    carta.SetActive(false);
                    e.SetActive(false);
                    Time.timeScale = 1;
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

