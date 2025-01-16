using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Single : MonoBehaviour
{
    public GameObject singlePrefab;  // Reference to the Single prefab
    public Transform parent;  // Parent to place the instantiated object
    public float spacing = 100f;  // Spacing between letters
    public float verticalSpacing = 50f;  // Vertical spacing between top and bottom halves

    void Start()
    {
        List<char> alphabet = new List<char>();
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            alphabet.Add(letter);
        }

        // Instantiate and center the letters
        InstantiateLetters(alphabet);
    }

    void InstantiateLetters(List<char> letters)
    {
        int halfCount = letters.Count / 2;  // Calculate the half point of the list

        // Calculate the total width and height needed for all letters
        float totalWidth = (letters.Count / 2) * spacing;  // Width for one row
        float totalHeight = verticalSpacing;  // Only one vertical gap between the top and bottom halves

        Vector3 startPosition = parent.position;

        // Calculate the initial horizontal offset to center the letters
        float centerOffsetX = -totalWidth / 2;
        // Calculate the initial vertical offset to center the letters
        float centerOffsetY = totalHeight / 2;

        // Loop through the first half of the list (above)
        Vector3 firstHalfStartPosition = startPosition + new Vector3(centerOffsetX, centerOffsetY, 0);
        Vector3 currentPosition = firstHalfStartPosition;

        for (int i = 0; i < halfCount; i++)
        {
            char letter = letters[i];
            GameObject newSingle = Instantiate(singlePrefab, currentPosition, Quaternion.identity);
            newSingle.transform.SetParent(parent);

            TextMeshProUGUI textComponent = newSingle.GetComponentInChildren<TextMeshProUGUI>();
            textComponent.text = letter.ToString();

            // Adjust the position for the next letter (horizontal spacing)
            currentPosition.x += spacing;
        }

        // Start the second half of the list (below)
        Vector3 secondHalfStartPosition = startPosition + new Vector3(centerOffsetX, -centerOffsetY, 0);
        currentPosition = secondHalfStartPosition;

        // Loop through the second half of the list (below)
        for (int i = halfCount; i < letters.Count; i++)
        {
            char letter = letters[i];
            GameObject newSingle = Instantiate(singlePrefab, currentPosition, Quaternion.identity);
            newSingle.transform.SetParent(parent);

            TextMeshProUGUI textComponent = newSingle.GetComponentInChildren<TextMeshProUGUI>();
            textComponent.text = letter.ToString();

            // Adjust the position for the next letter (horizontal spacing)
            currentPosition.x += spacing;
        }
    }
}
