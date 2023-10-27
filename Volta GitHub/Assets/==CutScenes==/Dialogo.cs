using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    private string[] sentences; // Uma matriz de frases do di�logo
    private int currentSentenceIndex = 0; // �ndice da frase atual
    public float displayTimePerCharacter = 0.05f; // Tempo para exibir cada caractere
    public float pauseBetweenSentences = 1.0f; // Tempo de pausa entre frases

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Defina as frases do di�logo (substitua pelo seu pr�prio di�logo)
        sentences = new string[]
        {
            "'' Eles me abandonaram." 
            + Environment.NewLine + "Ainda tenho a memória muito vívida daquela noite; era véspera do meu aniversário, 12 anos."
            + Environment.NewLine + "Como de costume, eles sempre apareciam à meia-noite para me parabenizar. Mas, naquela noite foi diferente."
            + Environment.NewLine + "Eu lembro que estava deitado, e de vez em quando espiava o relógio. Os minutos pareciam intermináveis e o silêncio tomou conta."
            + Environment.NewLine + "Pouco tempo depois, tomei coragem e saí do quarto. Procurei-os por toda a casa, nem sinal. Contudo, decidi sair na rua e os procurar, mas, nem vestígio. Resolvi voltar e dormir, torcendo que fosse algum tipo de brincadeira."
            + Environment.NewLine + "Entretanto, nunca mais os encontrei. Desde aquele dia, passei meus anos vivendo sozinho aqui nesta casa, com grande angustia e raiva, sigo dizendo: eles me abandonaram.''"
            + Environment.NewLine + ""
            + Environment.NewLine + "- Cronópio"
            
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