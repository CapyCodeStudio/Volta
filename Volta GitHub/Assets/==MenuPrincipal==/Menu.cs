using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject menuPause;
    [SerializeField] private string cenaDoJogo;

    // Update is called once per frame
    private void Start()
    {


    }
    void Update()
    {

        if (Input.GetButtonDown("Cancel") && !menuPause.activeSelf)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0;

        }
        else if (Input.GetButtonDown("Cancel") && menuPause.activeSelf)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void Jogar()
    {
        SceneManager.LoadScene(cenaDoJogo);
    }
    public void SairJogo()
    {
        Application.Quit();
    }


}



