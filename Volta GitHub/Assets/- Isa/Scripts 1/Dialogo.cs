using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    private string[] sentences; // Uma matriz de frases do di�logo
    private int currentSentenceIndex = 0; // �ndice da frase atual
    public float displayTimePerCharacter = 0.05f; // Tempo para exibir cada caractere
    public float pauseBetweenSentences = 1.0f; // Tempo de pausa entre frases

    private void Start()
    {
        // Defina as frases do di�logo (substitua pelo seu pr�prio di�logo)
        sentences = new string[]
        {
            "Ol�, jogador!",
            "Bem-vindo ao meu jogo.",
            "Estou feliz que voc� esteja aqui.",
            "Vamos come�ar!"
        };

        // Inicie o di�logo
        StartCoroutine(StartDialog());
    }

    private IEnumerator StartDialog()
    {
        foreach (char letter in sentences[currentSentenceIndex])
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(displayTimePerCharacter);
        }

        yield return new WaitForSeconds(pauseBetweenSentences);

        // Avance para a pr�xima frase
        currentSentenceIndex++;

        // Verifique se h� mais frases
        if (currentSentenceIndex < sentences.Length)
        {
            // Inicie a pr�xima frase
            dialogText.text = "";
            StartCoroutine(StartDialog());
        }
        else
        {
            // Fim do di�logo, voc� pode adicionar a l�gica desejada aqui
            Debug.Log("Fim do di�logo");
        }
    }
}
