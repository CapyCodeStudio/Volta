using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenhaMorse : MonoBehaviour
{
    public bool tocando;

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
            if (Input.GetButton("E"))
            {
                SceneManager.LoadScene("SenhaMorse");
            }
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
