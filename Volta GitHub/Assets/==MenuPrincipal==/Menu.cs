using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string cenaDoJogo;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
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
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(cenaDoJogo);
    }
   


}



