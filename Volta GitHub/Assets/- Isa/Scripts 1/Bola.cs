using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public bool tocando;
    // public BoxCollider carta;
    public GameObject f;
    public GameObject bola;


    private void Update()
    {
        if (tocando)
        {
            f.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("F"))
            {
               
                bola.SetActive(false);
                f.SetActive(false);
               
               
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
            f.SetActive(false);

        }
    }
}
