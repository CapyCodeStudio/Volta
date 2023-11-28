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
          "Alô, testando… Isso, consegui. Olá, estou gravando essa fita para que você possa seguir a jornada e voltar para casa. Lamento que tenha caído em um lugar tão hostil quanto este, mas se alguém realmente chegar a ouvir essas fitas, especialmente você, Cronópio, então meus cálculos funcionaram! Sou o Viajante, e durante minhas pesquisas e jornadas, descobri que ondas de rádio podem ser captadas e atravessam qualquer canto do multiverso..",
          "Então, se você ouviu algo estranho, provavelmente fui eu. E sim, você não ouviu errado, multiverso. E, embora você esteja neste momento na sua casa, acredite, este não é exatamente seu lar, pois essa casa, esse lugar, esta realidade é uma paralela ao lugar que você pertence. Ainda tem muitas coisas que eu preciso te contar, te ajudarei a passar pelos desafios que encontrará e quando me encontrar, te explico tudo, prometo.\r\n",
          "Estou em uma prisão interdimensional. Perdi a noção de quanto tempo se passou desde que cheguei aqui - semanas, meses, anos, não tenho ideia.",
          "Ainda não encontrei uma maneira de escapar, é preocupante. Já explorei vários universos diferentes, e em todos eles consegui me transportar. No entanto, parece que há uma barreira ou algo assim que me impede de sair daqui. Tudo isso me leva a crer que eu estou em uma região ‘cinza’ do multiverso, que basicamente são pequenos filamentos, agrupamentos de realidades que ficam distantes do núcleo do multiverso.",
          "Bom, vamos ao que interessa. Certamente você deve ter notado um objeto estranho que emite uma luz muito forte, o objeto no qual te levou até aqui. O apelidei carinhosamente de Voyager.\r\n\r\nTodos os viajantes interdimensionais (ou pelo menos a maioria deles) possuem uma Voyager, e são essas que nos permitem viajar para diferentes realidades. Elas funcionam da seguinte forma:\r\n",
          "O núcleo é um catalisador de impulsos quânticos, que cria uma abertura no espaço-tempo, formando uma espécie de \"portal\" para outra realidade. O painel, por sua vez, é um localizador, onde você insere um código específico relacionado ao universo para o qual deseja se transportar. Cada universo possui um código pré-definido, e não saberia explicar exatamente o motivo, especialmente porque desconheço a origem deste objeto misterioso.",
          "Você com certeza deve ter pensado que eu também possuo uma Voyager, e sim, eu também tenho uma e carrego para todos os cantos. Entretanto, algo muito grave aconteceu e no momento não estou com ela em mãos, eu posso te explicar melhor quando nos encontrarmos.",
          "Você deve se perguntar: \"Então, o que posso fazer?\" A resposta é complexa, mas posso lhe assegurar que sem você não vou conseguir resolver isso. Precisamos trabalhar juntos para recuperar minha Voyager através da sua.",
          "Ah,caso eu não esteja mais neste local, peço que continue sua busca. Certamente, não me afastarei muito, a menos que ocorra algo inesperado.\r\nA alguns metros daqui, eu encontrei uma caverna. Se eu não estiver aqui, certamente estarei lá. Boa sorte.",
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