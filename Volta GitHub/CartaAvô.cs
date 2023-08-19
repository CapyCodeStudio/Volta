using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartaAvô : MonoBehaviour
{
    public GameObject cronopio;
    float perto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*perto = Vector3.Distance(cronopio.transform.position, transform.position);
        print(perto);*/

        if(Input.GetButton("E"))
    {
            if (perto < 7)
            {
                //Destroy(gameObject);
                SceneManager.LoadScene("Universo1");

                //cronopio.GetComponent<SpriteRenderer>().color = Color.yellow;
            }

        }
    }
    
}
