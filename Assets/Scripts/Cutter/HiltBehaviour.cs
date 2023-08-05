using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiltBehaviour : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutter = null;
    [SerializeField] BoxCollider _hiltCollider = null;
    [SerializeField] List<string> cuttableTags;

    private void OnTriggerEnter(Collider other)
    {
        if (_cutter.CutterFrozen) return;

        for(int i = 0; i < cuttableTags.Count; i++)
        {
            if (other.CompareTag(cuttableTags[i])) return;
        }

        _cutter.Bounce();
    }
}
