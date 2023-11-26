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
            "Os holofotes são acesos e revelam a misteriosa figura que ele era. Quero dizer, eu o conhecia mas, não conhecia as suas origens. Independente disso, ele sempre foi bom comigo, era como um pai para mim." 
            + Environment.NewLine + "Éramos sós, não tínhamos mais ninguém, mas aprendemos a lidar com a solidão de duas pessoas. Tendo aquela vida mediana e pacata, eu jamais imaginaria o que estava por vir."
            + Environment.NewLine + " "
            + Environment.NewLine + "Naquela noite, uma luz intensa e fantasmagórica envolveu meu avô, uma luminosidade tão brilhante que ofuscou tudo ao seu redor. Ele foi levado por aquilo, desaparecendo para sempre."
            + Environment.NewLine + "O seu desaparecimento lançou-me uma sombra de dubiedade existencial, uma sombra da incerteza e da perda em contraste com a luz que o tirou de mim. Isso não é uma quimera; é uma realidade tangível, mas uma realidade que escapa à minha compreensão."
            + Environment.NewLine + " "
            + Environment.NewLine + "Havia ali nele, uma essência que o fazia seguir sob qualquer circunstância, além de suas virtudes e o seu conhecimento memorável. Esta é a razão pela qual o escolheram, o arrancaram de mim, deixando-me aqui aprisionado, sem respostas."
            
            
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