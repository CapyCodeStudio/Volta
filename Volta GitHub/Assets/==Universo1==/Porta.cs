using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public bool tocando;
    public GameObject e;
    public GameObject porta;
    public GameObject portaAnimation;

    private void Update()
    {
        print("AAAAAAA");
        if (tocando && porta.activeSelf == false)
        {
            e.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("E"))
            {
                if (porta.activeSelf)
                {
                    porta.SetActive(false);
                    portaAnimation.SetActive(true);
                    e.SetActive(false);


                }
                else
                {
                    print("aperto o botao");
                    porta.SetActive(true);
                    portaAnimation.SetActive(false);
                    e.SetActive(false);

                }
            }
        }

        else if (tocando && porta.activeSelf == true)
        {
            if (Input.GetButtonDown("E"))
            {
                if (porta.activeSelf)
                {
                    porta.SetActive(false);
                    portaAnimation.SetActive(true);
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
