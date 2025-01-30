using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _completedClip;

    [SerializeField] private List<PuzzleSlot> _slotsPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotsParent, _pieceParent;
    [SerializeField] public int _slotCount = 3;

    [SerializeField] private Image _toggleImage;
    [SerializeField] private Sprite _autoRepeatOn, _autoRepeatOff;

    [SerializeField] private GameObject stageCompleted;

    private bool _isAutoRepeat;

    private int _placedCount = 0;

    private void Awake()
    {
        _isAutoRepeat = PlayerPrefs.GetInt("AutoRepeat", 0) == 1;
    }

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        UpdateToggleImage();

    }

    void Spawn()
    {
        // Create lists of indices for slots and pieces
        var availableSlotIndices = Enumerable.Range(0, _slotsParent.childCount).ToList();
        var availablePieceIndices = Enumerable.Range(0, _pieceParent.childCount).ToList();

        // Shuffle the slot prefabs
        var randomSet = _slotsPrefabs.OrderBy(s => Random.value).Take(_slotCount).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            // Randomly select an index for the slot and remove it from the available list
            int slotIndex = availableSlotIndices[Random.Range(0, availableSlotIndices.Count)];
            availableSlotIndices.Remove(slotIndex);

            // Spawn the slot
            var spawnedSlot = Instantiate(randomSet[i], _slotsParent.GetChild(slotIndex).position, Quaternion.identity);

            // Randomly select an index for the piece and remove it from the available list
            int pieceIndex = availablePieceIndices[Random.Range(0, availablePieceIndices.Count)];
            availablePieceIndices.Remove(pieceIndex);

            // Spawn the piece and initialize it with the spawned slot
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(pieceIndex).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);

        }
    }

    public void StageComplete()
    {
        _placedCount++;
        Debug.Log($"Placed Count: {_placedCount}");

        if (_placedCount == _slotCount)
        {
            // All pieces are placed
            _audioSource.PlayOneShot(_completedClip);
            if (_isAutoRepeat)
            {
                StartCoroutine(RestartGame());
            }
            else
            {
                stageCompleted.gameObject.SetActive(true); // Show the stage completed UI
            }
        }
    }

    private IEnumerator RestartGame()
    {
        Debug.Log("Game restarting...");
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void IsAutoRepeat()
    {
        _isAutoRepeat = !_isAutoRepeat;
        PlayerPrefs.SetInt("AutoRepeat", _isAutoRepeat ? 1 : 0); // Store the value
        PlayerPrefs.Save();
    }

    private void UpdateToggleImage()
    {
        if (_toggleImage != null)
        {
            _toggleImage.sprite = _isAutoRepeat ? _autoRepeatOn : _autoRepeatOff;
        }
    }
}