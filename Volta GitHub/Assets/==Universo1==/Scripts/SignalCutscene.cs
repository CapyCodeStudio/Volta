using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SignalCutscene : MonoBehaviour
{
    public PlayableDirector timeline; // Refer�ncia para o PlayableDirector da sua cutscene.
    public string nextSceneName; // Nome da cena que deve ser carregada ap�s a cutscene.

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

            // Carregue a pr�xima cena se um nome de cena v�lido estiver definido.
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    private void Update()
    {
        // Verifique se a cutscene terminou e permita a��es de in�cio do jogo aqui.
        if (cutsceneFinished)
        {
            // Por exemplo, ativar personagens, iniciar a jogabilidade, etc.
        }
    }
}