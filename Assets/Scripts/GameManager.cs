using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField, ReadOnly] private bool _gameRunning;
    [SerializeReference] List<string> _playerTags;

    [SerializeField, ReadOnly] int playerScore;

    public bool GameRunning
    {
        get => _gameRunning;
        set => _gameRunning = value;
    }

    public List<string> PlayerTags => _playerTags;

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

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        _gameRunning = true;
    }

    void AddScore(int value)
    {

    }

    void MultiplyPoints(int value)
    {

    }

    public void LoseGame()
    {

    }

    public void WinGame()
    {

    }
}
