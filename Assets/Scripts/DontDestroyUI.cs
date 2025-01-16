using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Ensure only one instance exists
        if (FindObjectsOfType<DontDestroyUI>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
