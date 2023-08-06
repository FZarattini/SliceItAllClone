using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBehaviour : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutter = null;
    [SerializeField] BoxCollider _bladeCollider = null;

    [Title("Setup")]
    [SerializeField] TagDataSO _tagData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagData.CuttableTag) || other.CompareTag(_tagData.CuttablePartTag))
        {
            return;
        }

        _cutter.FreezeObject();
    }
}
