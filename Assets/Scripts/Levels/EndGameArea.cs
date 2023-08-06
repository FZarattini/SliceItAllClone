using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameArea : MonoBehaviour
{
    [SerializeField] TagDataSO _tagData;

    // Handles the collision of the end game area with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagData.BladeTag) || other.CompareTag(_tagData.HiltTag))
            GameManager.Instance.LoseGame();
    }
}
