using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuControles;
    [SerializeField] private GameObject menuAudio;

    //[SerializeField] private GameObject carta;
    void Update()
    {
    
        if (Input.GetButtonDown("Cancel") && !menuPause.activeSelf && !menuControles.activeSelf && !menuAudio.activeSelf)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        
        else if (Input.GetButtonDown("Cancel") && menuPause.activeSelf)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    public void AtivarMenuControles()
    {
        menuControles.SetActive(true);
       
    }

  
    public void AtivarMenuAudio()
    {
        menuAudio.SetActive(true);
       
    }

    
    public void AtivarMenuCodigo()
    {
      
        if (!menuControles.activeSelf && !menuAudio.activeSelf)
        {
            
            Debug.Log("Menu de código ativado.");
           

        }
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}
