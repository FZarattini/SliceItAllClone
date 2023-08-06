using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    [Title("References and Data")]
    [SerializeField] TagDataSO _tagData;
    [SerializeField] TextMesh _scoreText;
    [SerializeField] int scoreAmount;

    [Title("Control")]
    [SerializeField, ReadOnly] bool scored;

    [Title("Events")]
    public static event Action<int> OnScoreAreaHit;

    private void Start()
    {
        _scoreText.text = $"+{scoreAmount}";
        scored = false;
    }

    // Handles collision with player, adds the score and ends the game
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_tagData.BladeTag) || scored) return;
        scored = true;

        OnScoreAreaHit?.Invoke(scoreAmount);

        GameManager.Instance.WinGame();
    }
}
