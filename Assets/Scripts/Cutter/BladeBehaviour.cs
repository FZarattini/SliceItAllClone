using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBehaviour : MonoBehaviour
{
    [Title("References")]
    [SerializeField] CutterBehaviour _cutter = null;

    [Title("Setup")]
    [SerializeField] TagDataSO _tagData;

    // Handles collision of the blade part of the Cutter Object with other colliders
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagData.CuttableTag) || other.CompareTag(_tagData.CuttablePartTag))
        {
            return;
        }

        _cutter.FreezeObject();
    }
}
