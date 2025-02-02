using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMatchPiece : MonoBehaviour
{
    private PuzzleMatchManager _puzzleManager;

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pickUpClip, _dropClip, _matchClip, _completedClip;

    private bool _dragging, _placed, _completed;

    private Vector2 _offset, _originalPosition;

    private PuzzleMatchSlot _slot;


    public void Init(PuzzleMatchSlot slot)
    {
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }

    private void Awake()
    {
        _originalPosition = transform.position;

        _puzzleManager = FindObjectOfType<PuzzleMatchManager>();
}

    private void Update()
    {
        if (_placed) return;
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        _dragging = true;

        _audioSource.PlayOneShot(_pickUpClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, _slot.transform.position) < 0.5f)
        {
            transform.position = _slot.transform.position;
            _slot.Placed();
            _placed = true;
            _audioSource.PlayOneShot(_matchClip);
            _puzzleManager.StageComplete();
        }
        else
        {
            transform.position = _originalPosition;
            _audioSource.PlayOneShot(_dropClip);

            _dragging = false;
        }
        
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
