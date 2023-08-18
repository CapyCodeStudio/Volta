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
            e.SetActive(true);
            //carta.isTrigger = true;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            carta.SetActive(true);
            tocando = true;

        }

    }
    public void OnTriggerExit(Collider collision)
    {
        carta.SetActive(false);
        e.SetActive(false);
        tocando = false;
        //carta.isTrigger = false;

    }

}
