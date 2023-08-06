using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Displays the player score, updated everytime the score changes in GameManager
public class ScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    private void Start()
    {
        SetInitialScore();
    }

    private void OnEnable()
    {
        GameManager.OnScoreChanged += UpdateScore;
        GameManager.OnRestartGame += SetInitialScore;
    }

    private void OnDisable()
    {
        GameManager.OnScoreChanged -= UpdateScore;
        GameManager.OnRestartGame -= SetInitialScore;
    }

    void UpdateScore(int value)
    {
        _scoreText.text = value.ToString();
    }

    void SetInitialScore()
    {
        _scoreText.text = "0";
    }
}
