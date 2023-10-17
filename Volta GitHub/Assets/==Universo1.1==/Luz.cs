using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public GameObject tela;
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            tela.SetActive(true);
        }
        else
        {
            tela.SetActive(false);
        }
    }
}
