using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    /*  Menus  */


    /*  Courses  */

    /*  KIDS  */

    public void Alphabet()
    {
        SceneManager.LoadScene("Alphabet");
    }

    public void GuessWord()
    {
        SceneManager.LoadScene("GuessWord");
    }

    public void WhackALetter()
    {
        SceneManager.LoadScene("WhackALetter");
    }

    public void PuzzlePair()
    {
        SceneManager.LoadScene("PuzzlePair");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
