using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Doozy.Runtime.UIManager.Containers;
using Sirenix.OdinInspector;

public class WinScreen : MonoBehaviour
{
    [Title("Prefab References")]
    [SerializeField] UIContainer _container;
    [SerializeField] TextMeshProUGUI _scoreValueText;
    [SerializeField] Button _continueButton;
    [SerializeField] Button _restartButton;

    private void OnEnable()
    {
        GameManager.OnWinGame += SetWinScreen;
    }

    private void OnDisable()
    {
        GameManager.OnWinGame -= SetWinScreen;
    }

    // Sets the screen data
    void SetWinScreen()
    {
        GameManager.Instance.GameRunning = false;

        _scoreValueText.text = GameManager.Instance.PlayerScore.ToString();

        var lastLevel = LevelManager.Instance.IsOnLastLevel;

        _continueButton.gameObject.SetActive(!lastLevel);
        _restartButton.gameObject.SetActive(lastLevel);

        _container.Show();
    }

    public void ContinueButton()
    {
        LevelManager.Instance.LoadNextLevel();
        _container.Hide();
    }

    public void RestartButton()
    {
        LevelManager.Instance.LoadFirstLevel();
        _container.Hide();
    }
}
