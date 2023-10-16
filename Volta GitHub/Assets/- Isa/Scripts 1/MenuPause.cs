using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuControles;
    [SerializeField] private GameObject menuAudio;
    [SerializeField] private GameObject carta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Cancel") && !menuPause.activeSelf)
        {
            menuPause.SetActive(true);
            //carta.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetButtonDown("Cancel") && menuPause.activeSelf)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
       /* if (Input.GetButtonDown("Cancel") && menuControles.activeSelf || Input.GetButtonDown("Cancel") && menuAudio.activeSelf || Input.GetButtonDown("Cancel") && carta.activeSelf)
        {
             menuPause.SetActive(false);
             Time.timeScale = 1;
             Cursor.lockState = CursorLockMode.None;
        }*/

    }
}
