using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GravacaoUniverso1 : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    private string[] sentences; // Uma matriz de frases do di�logo
    private int currentSentenceIndex = 0; // �ndice da frase atual
    public float displayTimePerCharacter = 0.002f; // Tempo para exibir cada caractere
    public float pauseBetweenSentences = 1.0f; // Tempo de pausa entre frases

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Defina as frases do di�logo (substitua pelo seu pr�prio di�logo)
        sentences = new string[]
        {
          "Lamento o seu mergulho neste reino hostil. Sou o Viajante, e se você é Cronópio, meus cálculos surtiram efeito. Ondas de rádio, fascinantes em sua travessia pelo multiverso, podem trazer minha voz para sua rádio. Este não é seu verdadeiro lar; está em uma realidade paralela, orientada por suas distorções. O clima é implacável, vida escassa, uma maldição paira. Pode parecer insanidade, mas aqui, a verdade é um véu tênue."

           +dialogText.text+ "DIDII"
        
        };

        // Inicie o di�logo
        StartCoroutine(StartDialog());
        
    }

    private IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(6.6f);

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