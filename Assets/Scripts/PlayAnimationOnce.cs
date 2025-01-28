using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnce : MonoBehaviour
{
    public string animationTrigger = "Play";

    void Start()
    {
        // Check if the animations have already been played
        if (!PlayerPrefs.HasKey("AnimationsPlayed"))
        {
            // Get all child GameObjects and play their animations
            foreach (Transform child in transform)
            {
                Animator animator = child.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger(animationTrigger);
                }
            }

            // Mark as played
            PlayerPrefs.SetInt("AnimationsPlayed", 1);
            PlayerPrefs.Save();
        }
    }
}
