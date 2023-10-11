using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controles : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    public Sprite activeImage;
    public Sprite originalImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        originalImage = buttonImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = activeImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = originalImage;
    }

}

