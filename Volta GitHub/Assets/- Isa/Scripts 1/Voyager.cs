using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voyager : MonoBehaviour
{
    public bool tocando;
    public GameObject e;
    public GameObject voyager;
    public GameObject caraComVoyager;
 
    private void Update()
    {
        if (tocando && voyager.activeSelf == false)
        {
            e.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("E"))
            {
                if (voyager.activeSelf)
                {
                    voyager.SetActive(false);
                    caraComVoyager.SetActive(false);
                    e.SetActive(false);
                }
                else
                {
                    print("aperto o botao");
                    voyager.SetActive(false);
                    caraComVoyager.SetActive(true);
                    e.SetActive(false);
                }
            }
        }

        else if (tocando && voyager.activeSelf == true)
        {
            if (Input.GetButtonDown("E"))
            {
                if (voyager.activeSelf)
                {
                    voyager.SetActive(false);
                    caraComVoyager.SetActive(true);
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
