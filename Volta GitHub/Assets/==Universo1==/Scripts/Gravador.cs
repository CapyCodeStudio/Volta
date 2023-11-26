using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravador : MonoBehaviour
{
    public bool tocando;
    public GameObject e;
    public GameObject mao;
    public GameObject chao;

    private void Update()
    {
        print("AAAAAAA");
        if (tocando && mao.activeSelf == false)
        {
            e.SetActive(true);
            print("tocou true");
            if (Input.GetButtonDown("E"))
            {
                if (mao.activeSelf)
                {
                    mao.SetActive(false);
                    chao.SetActive(true);
                    e.SetActive(false);


                }
                else
                {
                    print("aperto o botao");
                    mao.SetActive(true);
                    chao.SetActive(false);
                    e.SetActive(false);

                }
            }
        }

        else if (tocando && mao.activeSelf == true)
        {
            if (Input.GetButtonDown("E"))
            {
                if (mao.activeSelf)
                {
                    mao.SetActive(false);
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


