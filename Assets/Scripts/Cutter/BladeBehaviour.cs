using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBehaviour : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutter = null;
    [SerializeField] BoxCollider _bladeCollider = null;

    [Title("Setup")]
    [SerializeField] List<string> cuttableTags;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        for (int i = 0; i < cuttableTags.Count; i++) 
        {
            if (other.CompareTag(cuttableTags[i])) return;
        }

        _cutter.FreezeObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
