using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoCaverna : MonoBehaviour
{
    public string nomeDaProximaCena; // Nome da cena que voc� deseja carregar
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CarregarProximaCena();
        }
    }

    // M�todo chamado pela Timeline quando ela terminar
    public void CarregarProximaCena()
    {
        SceneManager.LoadScene(nomeDaProximaCena);
    }
}
