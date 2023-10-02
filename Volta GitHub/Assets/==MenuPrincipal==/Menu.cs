using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject menuPause;
    [SerializeField] private string cenaDoJogo;

    [SerializeField] private GameObject menuControles;
    [SerializeField] private GameObject menuIdioma;
    [SerializeField] private GameObject menuAudio;
    [SerializeField] private GameObject menuGraficos;
    [SerializeField] private GameObject carta;


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
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetButtonDown("Cancel") && menuPause.activeSelf)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetButtonDown("Cancel") && menuControles.activeSelf || Input.GetButtonDown("Cancel") && menuIdioma.activeSelf || Input.GetButtonDown("Cancel") && menuGraficos.activeSelf || Input.GetButtonDown("Cancel") && menuAudio.activeSelf || Input.GetButtonDown("Cancel") && carta.activeSelf)
        {
            menuPause.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void Jogar()
    {
        StartCoroutine(LoadScene());

        
    }
    public void SairJogo()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(cenaDoJogo);
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(cenaDoJogo);
    }
   


}



