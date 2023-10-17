using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*public class Keypad2 : MonoBehaviour
{
    [SerializeField] private string cenaDoJogo;
    public Color senhaCorretaColor = Color.green;
    public Color senhaIncorretaColor = Color.red;
    public TMP_InputField tela;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;
    public GameObject clear;
    public GameObject enter;

    public void b1()
    {
        tela.text = tela.text + "1";
    }
    public void b2()
    {
        tela.text = tela.text + "2";
    }
    public void b3()
    {
        tela.text = tela.text + "3";
    }
    public void b4()
    {
        tela.text = tela.text + "4";
    }
    public void b5()
    {
        tela.text = tela.text + "5";
    }
    public void b6()
    {
        tela.text = tela.text + "6";
    }
    public void b7()
    {
        tela.text = tela.text + "7";
    }
    public void b8()
    {
        tela.text = tela.text + "8";
    }
    public void b9()
    {
        tela.text = tela.text + "9";
    }
    public void b0()
    {
        tela.text = tela.text + "0";
    }
    public void clearEvent()
    {
        tela.text = null;
    }
    public void enterEvent()
    {
        if (tela.text == "1234")
        {
            tela.text = "Senha Correta";
            tela.color = senhaCorretaColor;
            StartCoroutine(LoadSceneAfterDelay());
        }
        else
        {
            tela.text = "Senha Incorreta";
            tela.color = senhaIncorretaColor;
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
        tela.color = Color.white; // Volta para a cor padrão
    }
}*/
