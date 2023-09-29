using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controles : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    public Sprite activeImage;
    private Sprite defaultImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        defaultImage = buttonImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = activeImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = defaultImage;
    }

}

