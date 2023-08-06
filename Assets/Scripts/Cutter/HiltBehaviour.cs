using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiltBehaviour : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutter = null;
    [SerializeField] BoxCollider _hiltCollider = null;
    [SerializeField] TagDataSO _tagData = null;

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
