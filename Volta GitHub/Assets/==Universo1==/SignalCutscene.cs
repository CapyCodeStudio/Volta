using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SignalCutscene : MonoBehaviour
{
    public PlayableDirector timeline; // Referência para o PlayableDirector da sua cutscene.
    public string nextSceneName; // Nome da cena que deve ser carregada após a cutscene.

    private bool cutsceneFinished = false;

    private void Start()
    {
        if (timeline != null)
        {
            timeline.stopped += OnTimelineStopped; // Assine o evento de parada da timeline.
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        if (director == timeline)
        {
            // A cutscene terminou.
            cutsceneFinished = true;

            // Carregue a próxima cena se um nome de cena válido estiver definido.
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    private void Update()
    {
        // Verifique se a cutscene terminou e permita ações de início do jogo aqui.
        if (cutsceneFinished)
        {
            // Por exemplo, ativar personagens, iniciar a jogabilidade, etc.
        }
    }
}