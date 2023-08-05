using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelManager : MonoBehaviour
{
    [Title("Control")]
    [SerializeField] Transform _levelParent;
    [SerializeField] List<GameObject> _levelPrefabs;
    [SerializeField, ReadOnly] GameObject currentLevel = null;
    [SerializeField, ReadOnly] int currentLevelIndex;

    private void Awake()
    {
        currentLevelIndex = 0;

        LoadLevel(currentLevelIndex);
    }

    void LoadNextLevel()
    {
        currentLevelIndex++;
        LoadLevel(currentLevelIndex);
    }

    void LoadLevel(int index)
    {
        ClearCurrentLevel();

        currentLevel = Instantiate(_levelPrefabs[index], _levelParent);
    }

    void ClearCurrentLevel()
    {
        if (currentLevel == null) return;

        Destroy(currentLevel);
    }
}
