using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Title("Game State and Player Score")]

    [SerializeField, ReadOnly] private bool _gameRunning;
    [SerializeField, ReadOnly] int playerScore;

    [Title("Events")]
    public static event Action OnLoseGame;
    public static event Action OnWinGame;
    public static event Action OnRestartGame;
    public static event Action<int> OnScoreChanged;

    public bool GameRunning
    {
        get => _gameRunning;
        set => _gameRunning = value;
    }

    public int PlayerScore => playerScore;

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
        CuttableObject.OnObjectCut += AddScore;
        ScoreArea.OnScoreAreaHit += AddScore;

        StartGame();
    }

    private void OnDestroy()
    {
        CuttableObject.OnObjectCut -= AddScore;
        ScoreArea.OnScoreAreaHit -= AddScore;
    }

    public void StartGame()
    {
        _gameRunning = true;
    }

    void AddScore(int value)
    {
        playerScore += value;
        OnScoreChanged?.Invoke(playerScore);
    }

    public void RestartGame()
    {
        playerScore = 0;
        OnRestartGame?.Invoke();
    }

    public void LoseGame()
    {
        OnLoseGame?.Invoke();
    }

    public void WinGame()
    {
        OnWinGame?.Invoke();
    }
}
