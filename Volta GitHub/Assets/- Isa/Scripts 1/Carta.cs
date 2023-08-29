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
        if (Input.GetButtonDown("E") && tocando == true)
        {
            e.SetActive(false);
            carta.SetActive(true);
            Time.timeScale = 0;
            //carta.isTrigger = true;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            carta.SetActive(false);
            e.SetActive(true);
            tocando = true;
            Time.timeScale = 1;

        }

    }
    public void OnTriggerExit(Collider collision)
    {
        carta.SetActive(false);
        e.SetActive(false);
        tocando = false;
        Time.timeScale = 1;
        //carta.isTrigger = false;

    }

}
