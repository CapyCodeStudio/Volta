/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Criatura: MonoBehaviour
{
    public int vida = 10;
    private Animator animator;



    void Start()
    {
        Animator animator = GetComponent<Animator>();   
    }


    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if(vida <= 0)
        {
            animator.SetBool("Die", true);
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
*/