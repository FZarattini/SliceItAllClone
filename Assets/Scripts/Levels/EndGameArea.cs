using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        foreach(string s in GameManager.Instance.PlayerTags)
        {
            if (other.CompareTag(s))
                GameManager.Instance.LoseGame();
        }
    }
}
