using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomLetterAssigner : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Drag your prefab here in the Inspector

    void Start()
    {
        // Get all the Mole objects in MoleContainer
        foreach (Transform mole in transform)
        {
            // Find the "Black" child inside the Mole
            Transform black = mole.Find("Black");
            if (black != null)
            {
                // Instantiate the prefab as a child of "Black"
                GameObject instantiatedObject = Instantiate(prefabToInstantiate, black);
                instantiatedObject.transform.localPosition = Vector3.zero; // Reset position
                instantiatedObject.transform.localRotation = Quaternion.identity; // Reset rotation
                instantiatedObject.transform.localScale = Vector3.one; // Reset scale
            }
        }
    }

    //// Array of letters to choose from
    //private readonly char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    //void Start()
    //{
    //    // Loop through each Mole object under MoleContainer
    //    foreach (Transform mole in transform)
    //    {
    //        // Find Black -> Letter
    //        Transform black = mole.Find("Black");
    //        if (black != null)
    //        {
    //            Transform letterTransform = black.Find("Letter");
    //            if (letterTransform != null)
    //            {
    //                // Get the TMP_Text component
    //                TMP_Text textMeshPro = letterTransform.GetComponent<TMP_Text>();
    //                if (textMeshPro != null)
    //                {
    //                    // Assign a random letter
    //                    textMeshPro.text = GetRandomLetter();
    //                    Debug.Log($"Assigned {textMeshPro.text} to {letterTransform.name}");
    //                }
    //                else
    //                {
    //                    Debug.LogWarning($"No TMP_Text found on {letterTransform.name}");
    //                }
    //            }
    //            else
    //            {
    //                Debug.LogWarning($"Letter object not found under {black.name}");
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogWarning($"Black object not found under {mole.name}");
    //        }
    //    }
    //}

    //private string GetRandomLetter()
    //{
    //    return letters[Random.Range(0, letters.Length)].ToString();
    //}
}