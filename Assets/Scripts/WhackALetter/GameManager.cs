using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    //StartCoroutine(CountdownCoroutine());
    //private IEnumerator CountdownCoroutine()
    //{
    //    if (moleContainer != null)
    //    {
    //        moleContainer.SetActive(false);
    //    }

    //    yield return new WaitForSeconds(1f);

    //    while (countdownValue > 0)
    //    {
    //        countdownText.text = countdownValue.ToString();
    //        countdownText.fontSize = 620;
    //        yield return new WaitForSeconds(1f);
    //        countdownValue--;
    //    }

    //    // Display "Start!" after countdown
    //    countdownText.text = "Start!";
    //    countdownText.fontSize = 120;

    //    yield return new WaitForSeconds(1f);
    //    countdownText.text = ""; // Clear the text
    //    countdownText.gameObject.SetActive(false);

    //    yield return new WaitForSeconds(1f);
    //    if (moleContainer != null)
    //    {
    //        moleContainer.SetActive(true);
    //    }
    //}
}
