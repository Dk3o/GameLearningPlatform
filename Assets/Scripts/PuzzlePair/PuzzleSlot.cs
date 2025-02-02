using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;

    [SerializeField] private AudioSource _audioSource;

    public void Placed()
    {
        _audioSource.Play();
    }
}
