using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRepeat : MonoBehaviour
{
    private bool _isAutoRepeat = false; // The bool you want to change

    // Method to change the bool
    public void IsAutoRepeat()
    {
        _isAutoRepeat = !_isAutoRepeat;
    }
}
