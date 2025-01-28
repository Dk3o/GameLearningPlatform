using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RandomLetter : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] spriteOptions; // Drag sprites into this array in the Inspector
    private Image imageComponent;

    void Start()
    {
        imageComponent = GetComponent<Image>();

        if (imageComponent != null && spriteOptions.Length > 0)
        {
            imageComponent.sprite = GetRandomSprite();
        }
    }

    Sprite GetRandomSprite()
    {
        // Return a random sprite from the array
        int randomIndex = Random.Range(0, spriteOptions.Length);
        return spriteOptions[randomIndex];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Destroy the object when clicked
        Destroy(gameObject);
    }
}
