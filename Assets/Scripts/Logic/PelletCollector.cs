using System;
using UnityEngine;
using TMPro;

public class PelletCollector : MonoBehaviour
{
    public static PelletCollector Instance;

    [Header("References")]
    [SerializeField] private PelletSpawner _pelletSpawner;
    [SerializeField] private GameController _gameController;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _counter;

    private int _numberToCollect;
    private int _numberCollected;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (_pelletSpawner == null) Debug.LogError("PelletSpawner is not assigned!");
        if (_gameController == null) Debug.LogError("GameController is not assigned!");
        if (_audioSource == null) Debug.LogError("AudioSource is not assigned!");
        if (_counter == null) Debug.LogError("Counter Text is not assigned!");

        if (_pelletSpawner != null)
            _numberToCollect = _pelletSpawner.NumberToSpawn;

        ResetCounter();
    }

    public void ResetCounter()
    {
        _numberCollected = 0;
        if (_counter != null)
            _counter.text = "0";
    }

    public void PelletCollected()
    {
        if (_audioSource != null && _audioSource.clip != null)
            _audioSource.PlayOneShot(_audioSource.clip);

        _numberCollected++;

        if (_counter != null)
            _counter.text = _numberCollected.ToString();

        if (_numberCollected >= _numberToCollect && _gameController != null)
        {
            _gameController.EndGame();
        }
    }
}
