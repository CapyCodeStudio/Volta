using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class FadeVolta : MonoBehaviour
{
    private Image voltaFade;
    private Color color;
    private Color transparentColor;

    [Range(0.5f, 5f)]
    [SerializeField] private float fadeOutDuration = 1f;

    [Range(0.5f, 5f)]
    [SerializeField] private float fadeInDuration = 1f;

    private void Awake()
    {
        voltaFade = GetComponent<Image>();
        color = new Color(0, 0, 0, 1);
        transparentColor = new Color(0, 0, 0, 1);
    }


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(FadeOut());
        yield return null; 
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator DoFade(Color a, Color b, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            voltaFade.material.color = Color.Lerp(a, b, (elapsedTime / duration));
            yield return null;
        }

    }

    private IEnumerator FadeOut()
    {
        yield return StartCoroutine(DoFade(color, transparentColor, fadeOutDuration));
    }


    private IEnumerator FadeIn()
    {
        yield return StartCoroutine(DoFade(transparentColor, color, fadeInDuration));
    }

}
