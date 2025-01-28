using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCountDown : MonoBehaviour
{
    public TMP_Text countdownText; // Uncomment for TextMeshPro
    private int countdownValue = 3;
    public GameObject objectToDisable;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }

        yield return new WaitForSeconds(1f);

        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();
            countdownText.fontSize = 620;
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }

        // Display "Start!" after countdown
        countdownText.text = "Start!";
        countdownText.fontSize = 120;

        yield return new WaitForSeconds(1f);
        countdownText.text = ""; // Clear the text
        countdownText.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(true);
        }
    }
}
