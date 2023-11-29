using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GravacaoUniverso1 : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public GameObject collider, gravador, gravador2, portaUI;
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
          "Oi, tá funcionando? Olá sou o viajante e estou deixando essas gravações para te guiar de volta para casa, Cronópio. Lamento o lugar hostil onde você caiu, mas se alguém, especialmente você, ouvir essas fitas, então meus cálculos deram certo! Durante minhas pesquisas, descobri que as ondas de rádio podem atravessar qualquer canto do multiverso. Se ouviu algo estranho, provavelmente fui eu. Embora você esteja na sua casa, não é seu lar; esta é uma realidade paralela à sua.\r\n",
          "Estou preso em uma prisão interdimensional e ainda não encontrei uma maneira de escapar. Perdi a noção do tempo desde que cheguei aqui - semanas, meses, anos... Certamente, você notou um objeto estranho que emite luz forte, a Voyager. Ela nos leva a diferentes realidades. O núcleo cria um portal no espaço-tempo, enquanto o painel localiza universos por meio de códigos específicos.\r\n\r\n",
          "Eu também tenho uma Voyager, mas algo grave aconteceu, e não estou com ela no momento. Explicarei melhor quando nos encontrarmos. A resposta sobre o que fazer é complexa, mas sem você, não consigo resolver. Precisamos juntos recuperar minha Voyager através da sua.",
          "Caso eu não esteja mais aqui, continue buscando. Não me afastarei muito, a menos que algo inesperado ocorra. Encontrei uma caverna alguns metros daqui. Se não estiver aqui, estarei lá. Boa sorte!",
          "Desligo"

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
            collider.SetActive(false);
            gravador.SetActive(false);
            gravador2.SetActive(true);
            portaUI.SetActive(true);
            Debug.Log("Fim do di�logo");
        }
    }

}