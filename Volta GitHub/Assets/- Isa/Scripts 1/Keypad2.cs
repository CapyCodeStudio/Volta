using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Keypad2 : MonoBehaviour
{
    [SerializeField] private string cenaDoJogo;
    public TMP_InputField tela;
    public GameObject button1;
    public GameObject button2;
    public GameObject clear;
    public GameObject enter;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Start()
    {
       
    }
    public void b1()
    {
        tela.text = tela.text + ".";
    }
    public void b2()
    {
        tela.text = tela.text + "-";
    }
    public void clearEvent()
    {
        tela.text = null;
    }
    public void enterEvent()
    {
        if (tela.text == ".--..--")
        {
            tela.text = "CORRETO";
            
            StartCoroutine(LoadSceneAfterDelay());
        }
        else
        {
            tela.text = "INCORRETO";
            
            StartCoroutine(ClearTextAfterDelay());
        }
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(cenaDoJogo);
    }

    IEnumerator ClearTextAfterDelay()
    {
        yield return new WaitForSeconds(2);
        tela.text = "";
        
    } 
}