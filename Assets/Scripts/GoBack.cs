using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public string sceneName;

    public void GoToPreviousScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
