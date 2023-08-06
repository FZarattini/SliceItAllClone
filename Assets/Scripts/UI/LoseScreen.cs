using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] UIContainer _container;
    [SerializeField] Button _restartButton;


    private void OnEnable()
    {
        GameManager.OnLoseGame += OpenLoseScreen;
    }

    private void OnDisable()
    {
        GameManager.OnLoseGame -= OpenLoseScreen;
    }

    void OpenLoseScreen()
    {
        GameManager.Instance.GameRunning = false;
        _container.Show();
    }

    public void RestartButton()
    {
        LevelManager.Instance.ReloadLevel();
        _container.Hide();
    }
}
