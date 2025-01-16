using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedVoice : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PlaySoundWithDelay(5f));
    }

    IEnumerator PlaySoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
