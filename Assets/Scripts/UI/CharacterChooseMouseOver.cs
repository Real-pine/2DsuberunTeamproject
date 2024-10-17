using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterChooseMouseOver : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite hoverImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        characterImage.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        characterImage.sprite = defaultImage;
    }
}
