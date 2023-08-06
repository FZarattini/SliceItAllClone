using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    
    public static LevelManager Instance;

    [Title("Scene References")]
    [SerializeField] CinemachineVirtualCamera _vcam;
    [SerializeField, ReadOnly] CutterBehaviour _cutterBehaviour;

    [Title("Control")]
    [SerializeField] Transform _levelParent;
    [SerializeField] List<GameObject> _levelPrefabs;
    [SerializeField, ReadOnly] GameObject currentLevel = null;
    [SerializeField, ReadOnly] int currentLevelIndex;
    [SerializeField, ReadOnly] bool isOnLastLevel;

    public bool IsOnLastLevel => isOnLastLevel;

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

    private void OnEnable()
    {
        GameManager.OnRestartGame += LoadFirstLevel;
    }

    private void OnDisable()
    {
        GameManager.OnRestartGame -= LoadFirstLevel;
    }

    private void Start()
    {
        isOnLastLevel = false;
        LoadFirstLevel();
    }

    public void LoadFirstLevel()
    {
        currentLevelIndex = 0;
        LoadLevel(currentLevelIndex);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        LoadLevel(currentLevelIndex);
    }

    public void ReloadLevel()
    {
        LoadLevel(currentLevelIndex);
    }

    // Instantiates the current level prefab from the prefab list
    [Button]
    void LoadLevel(int index)
    {
        ClearCurrentLevel();

        currentLevel = Instantiate(_levelPrefabs[index], _levelParent);

        var levelReferences = currentLevel.GetComponent<LevelReferences>();

        if (levelReferences != null)
        {
            _cutterBehaviour = levelReferences.CutterBehaviour;
            SetupCamera();
        }

        isOnLastLevel = (currentLevelIndex == _levelPrefabs.Count - 1);

        GameManager.Instance.StartGame();
    }

    // Unloads the current loaded level
    void ClearCurrentLevel()
    {
        if (currentLevel == null) return;

        Destroy(currentLevel);
    }

    void SetupCamera()
    {
        _vcam.Follow = _cutterBehaviour.transform;
        _vcam.LookAt = _cutterBehaviour.transform;
    }
}
