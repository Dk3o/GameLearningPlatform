using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleMatchManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _completedClip;

    [SerializeField] private List<PuzzleMatchSlot> _slotsPrefabs;
    [SerializeField] private PuzzleMatchPiece _piecePrefab;
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
        // Directly take the first `_slotCount` slots without shuffling
        var selectedSlots = _slotsPrefabs.Take(_slotCount).ToList();

        for (int i = 0; i < selectedSlots.Count; i++)
        {
            // Place the slot in the corresponding child position
            var spawnedSlot = Instantiate(selectedSlots[i], _slotsParent.GetChild(i).position, Quaternion.identity);

            // Spawn the piece at the corresponding child position
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
            Debug.Log($"Spawned piece: {spawnedPiece}");
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