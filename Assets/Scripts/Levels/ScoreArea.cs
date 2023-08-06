using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    [SerializeField] int scoreAmount;
    [SerializeField] TagDataSO _tagData;
    [SerializeField] TextMesh _scoreText;

    public static event Action<int> OnScoreAreaHit;


    private void Start()
    {
        _scoreText.text = $"+{scoreAmount}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_tagData.BladeTag)) return;

        GameManager.Instance.WinGame();
    }
}
