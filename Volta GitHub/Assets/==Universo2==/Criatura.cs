using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criatura: MonoBehaviour
{
    public int vida = 10;
    


    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
        vida--;
        vida--;
        vida--;
        vida--;
        vida--;
        print("aaaaa");
    }

}
