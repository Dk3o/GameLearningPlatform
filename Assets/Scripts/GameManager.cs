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

}
