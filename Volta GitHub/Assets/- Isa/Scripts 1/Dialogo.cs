using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    private string[] sentences; // Uma matriz de frases do diálogo
    private int currentSentenceIndex = 0; // Índice da frase atual
    public float displayTimePerCharacter = 0.05f; // Tempo para exibir cada caractere
    public float pauseBetweenSentences = 1.0f; // Tempo de pausa entre frases

    private void Start()
    {
        // Defina as frases do diálogo (substitua pelo seu próprio diálogo)
        sentences = new string[]
        {
            "Olá, jogador!",
            "Bem-vindo ao meu jogo.",
            "Estou feliz que você esteja aqui.",
            "Vamos começar!"
        };

        // Inicie o diálogo
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

        // Avance para a próxima frase
        currentSentenceIndex++;

        // Verifique se há mais frases
        if (currentSentenceIndex < sentences.Length)
        {
            // Inicie a próxima frase
            dialogText.text = "";
            StartCoroutine(StartDialog());
        }
        else
        {
            // Fim do diálogo, você pode adicionar a lógica desejada aqui
            Debug.Log("Fim do diálogo");
        }
    }
}
