using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiltBehaviour : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutter = null;
    [SerializeField] TagDataSO _tagData = null;

    // Handles collision of the Hilt of the Cutter Object with other colliders
    private void OnTriggerEnter(Collider other)
    {
        if (_cutter.CutterFrozen) return;

        if (other.CompareTag(_tagData.CuttablePartTag))
        {
            return;
        }

        _cutter.Bounce();
    }
}
